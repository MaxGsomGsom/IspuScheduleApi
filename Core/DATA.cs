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
                DateTime tomorrow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);

                GroupSchedule sched = GroupSchedule.Generate(e.TimeTable.Where(el => 
                    el.StreamId == idGroup && el.DisciplineId != null && DateTime.Compare(tomorrow, el.Shedule.BegDate.Value) >= 0 && DateTime.Compare(DateTime.Now, el.Shedule.EndDate.Value) <= 0
                ).ToList());

                if (sched == null) {
                    sched = new GroupSchedule();
                    sched.Days = new List<TrainingDay>();
                }
                return sched;
            }
        }
    }
}