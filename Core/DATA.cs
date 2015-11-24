using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using DAL.Models;
using Faculty = Core.Domain.Faculty;
using System;

namespace Core
{
    /// <summary>
    ///     Интерфейст доступа к данным
    /// </summary>
    public static class DATA
    {
        /// <summary>
        ///     Возвращает список факультетов
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Faculty> GetFaculties()
        {
            using (var e = new AudienceEntities())
            {
                return e.Subdivision.Where(el => el.Id == el.FacultyId).AsEnumerable().Select(Faculty.Generage).ToList();
            }
        }

        /// <summary>
        ///     Возвращает список групп для указанного факультета
        /// </summary>
        /// <param name="idFaculty">Идентификатор факультета</param>
        /// <returns></returns>
        public static IEnumerable<Group> GetGroups(int idFaculty)
        {
            using (var e = new AudienceEntities())
            {
                return e.SubGroup.AsEnumerable().Where(el => el.Groups.SubDivisionId == idFaculty && el.TimeTable.Any()).Select(Group.Generate).ToList();
            }
        }

        /// <summary>
        ///     Возвращает рассписание для группы по идентификатору
        /// </summary>
        /// <param name="idGroup">Идентификатор группы</param>
        /// <returns></returns>
        public static GroupSchedule GetSchedule(int idGroup)
        {
            using (var e = new AudienceEntities())
            {
                //запас времени 14 дней используется, чтобы загружать расписание на 14 дней раньше, чем оно начинает действовать
                DateTime tomorrow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                tomorrow = tomorrow.AddDays(14);
                //список расписаний, период действия которых содержит сегодняшнее число
                List<Shedule> curSchedules = e.Shedule.Where(el => DateTime.Compare(tomorrow, el.BegDate.Value) >= 0 && DateTime.Compare(DateTime.Now, el.EndDate.Value) <= 0).ToList();

                //выбираем только нужные расписания из всех
                IQueryable<TimeTable> timeTable = e.TimeTable.Where((el) => el.StreamId == idGroup && el.DisciplineId != null);
                List<TimeTable> timeTableNow = new List<TimeTable>();

                foreach (Shedule item in curSchedules)
                {
                    timeTableNow.AddRange(timeTable.Where(el => el.SheduleId == item.Id));
                }

                GroupSchedule groupSched = GroupSchedule.Generate(timeTableNow);

                //если расписание пустое
                if (groupSched == null)
                    groupSched = new GroupSchedule();
                if (groupSched.Days == null)
                    groupSched.Days = new List<TrainingDay>();

                return groupSched;
            }
        }
    }
}