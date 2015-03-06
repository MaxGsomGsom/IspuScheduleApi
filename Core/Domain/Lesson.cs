using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain
{
    /// <summary>
    ///     Предмет
    /// </summary>
    public class Lesson
    {
        /// <summary>
        ///     Наименование предмета
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Тип
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        ///     Время начала
        /// </summary>
        public DateTime? TimeStart { get; set; }

        /// <summary>
        ///     Время окончания
        /// </summary>
        public DateTime? TimeEnd { get; set; }

        /// <summary>
        ///     Дата начала занятий
        /// </summary>
        public DateTime? DateStart { get; set; }

        /// <summary>
        ///     Дата окончания занятий
        /// </summary>
        public DateTime? DateEnd { get; set; }

        /// <summary>
        ///     Отдельные даты занятий
        /// </summary>
        public List<DateTime> Dates { get; set; }

        /// <summary>
        ///     Чётность
        /// </summary>
        public int? Parity { get; set; }

        /// <summary>
        ///     Преподаватели
        /// </summary>
        public List<Teacher> Teachers { get; set; }

        /// <summary>
        ///     Аудитории
        /// </summary>
        public List<Auditory> Auditories { get; set; }

        public static Lesson Generate(List<DAL.Models.TimeTable> instances)
        {
            if (instances == null || !instances.Any())
                return null;

            var instance = instances.First();

            var item = new Lesson();
            // заполняем общие поля
            item.Name = instance.Discipline.Name;
            if (instance.EducationKind != null)
                switch (instance.EducationKind.Name)
                {
                    case "лек.":
                        item.Type = 2;
                        break;
                    case "сем.":
                        item.Type = 3;
                        break;
                    case "лаб.":
                        item.Type = 1;
                        break;
                    case "зач.":
                        item.Type = 6;
                        break;
                    case "экз.":
                        item.Type = 7;
                        break;
                    default:
                        item.Type = 0;
                        break;
                }
            else
                item.Type = 0;

            item.TimeStart = instance.ETime.BegTime;
            item.TimeEnd = instance.ETime.EndTime;

            item.DateStart = instance.Shedule.BegDate;
            item.DateEnd = instance.Shedule.EndDate;



            //находим 1 сентября этого учебного года
            DateTime firstSeptember = new DateTime(DateTime.Now.Year, 9, 1);
            if (DateTime.Now<firstSeptember)
            {
                firstSeptember = new DateTime(DateTime.Now.Year -1, 9, 1);
            }

            //находим номер недели начала занятий в вузовском расписании, нумерация с 1 сентября
            int numOfWeeks = (int)Math.Ceiling(((instance.Shedule.BegDate.Value - firstSeptember).Days + (int)firstSeptember.DayOfWeek) / 7.0);
            
            //если четность недели начала занятий в вузовском расписании и с 1 сентября совпадают, то оставляем четность, иначе меняем недели местами
            if (((numOfWeeks % 2 == 0)? 2 : 1) == instance.Shedule.BegWeekNumber)
            {
                item.Parity = instance.WeekNumber;
            }
            else
            {
                item.Parity = instance.WeekNumber == 1 ? 2 : 1;
            }


            // извлекаем список преподавателей
            item.Teachers = instances.Where(el => el.Tutor != null).Select(el => Teacher.Generate(el.Tutor)).ToList();
            // извлекаем аудитории
            item.Auditories = instances.Where(el => el.Audience != null).Select(el => Auditory.Generate(el.Audience)).ToList();

            return item;
        }
    }
}