using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
        ///     Тип
        /// </summary>
        public string TypeString { get; set; }

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

        public static Lesson Generate(DAL.Models.TimeTable instance)
        {
            if (instance == null)
                return null;


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


            if (instance.EducationKind != null)
                switch (instance.EducationKind.ShortName)
                {
                    case "лек.":
                        item.TypeString = "Лекция";
                        break;
                    case "сем.":
                        item.TypeString = "Семинар";
                        break;
                    case "лаб.":
                        item.TypeString = "Лабораторная работа";
                        break;
                    case "зач.":
                        item.TypeString = "Зачет";
                        break;
                    case "экз.":
                        item.TypeString = "Экзамен";
                        break;
                    //case "пр.":
                    //    item.TypeString = "Практика";
                    //    break;
                    //case "к.пр.":
                    //    item.TypeString = "Практика";
                    //    break;
                    //case "к.":
                    //    item.TypeString = "Конcультация";
                    //    break;
                    default:
                        item.TypeString = "Практика";
                        break;
                }
            else
                item.TypeString = "Практика";

            item.TimeStart = instance.ETime.BegTime;
            item.TimeEnd = instance.ETime.EndTime;

            item.DateStart = instance.Shedule.BegDate;
            item.DateEnd = instance.Shedule.EndDate;

            //устанавливаем даты проведения занятий - однократные или периодические
            item.Dates = new List<DateTime>();
            if (instance.Date != null && Regex.IsMatch(instance.Date, "[0-9]{1,2}\\.[0-9]{1,2}"))
            {

                if (instance.Date.Contains("с"))
                {
                    DateTime d = DateTime.Parse(Regex.Match(instance.Date, "[0-9]{1,2}\\.[0-9]{1,2}").Value + "." + DateTime.Now.Year.ToString());

                    if (d < DateTime.Now) d = d.AddYears(1);

                    item.DateStart = d;
                }
                else 
                {
                    MatchCollection dates = Regex.Matches(instance.Date, "[0-9]{1,2}\\.[0-9]{1,2}");
                    foreach (Match date in dates)
                    {
                        DateTime d = DateTime.Parse(date.Value + "." + DateTime.Now.Year.ToString());

                        if (d < DateTime.Now) d = d.AddYears(1);

                        item.Dates.Add(d);
                    }
                }
            }


            //находим 1 января этого учебного года
            DateTime yearStart = new DateTime(DateTime.Now.Year, 1, 1);


            //находим номер недели начала занятий при нумерация с 1 января
            int numOfWeeks = (int)Math.Ceiling(((instance.Shedule.BegDate.Value - yearStart).Days + (int)yearStart.DayOfWeek) / 7.0);
            
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
            item.Teachers = new List<Teacher>();
            if (instance.Tutor != null)
                item.Teachers.Add(Teacher.Generate(instance.Tutor));

            // извлекаем аудитории
            item.Auditories = new List<Auditory>();
            if (instance.Audience != null)
                item.Auditories.Add(Auditory.Generate(instance.Audience));

            return item;
        }
    }
}