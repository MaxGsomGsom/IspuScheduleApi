using Core;
using Core.Domain;
using IspuScheduleApi2.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace IspuScheduleApi2.Factories
{
    /// <summary>
    ///     Фабрика для создания UI-модели "Группа"
    /// </summary>
    public static class UIGroupFactory
    {
        public static UIGroup Init(Group instance)
        {
            var item = new UIGroup();
            item.Name = instance.Name.TrimEnd(' ');

            GroupSchedule sched = DATA.GetSchedule(instance.Id);

            List<UILesson> lessons = new List<UILesson>();

            //переход от старого формата к новому, объединение учебных дней в один большой список
            foreach (TrainingDay day in sched.Days)
            {
                int weekday = day.WeekDay;
                foreach (Lesson lesson in day.Lessons)
                {
                    lessons.Add(UILessonFactory.Init(lesson, weekday));
                }
            }

            //объединение одинаковых предметов, различных лишь преподавателем и аудиторией
            List<IGrouping<UILesson, UILesson>> lessonsGroups = lessons.GroupBy((m) => { return m; }, new UILessonComparer()).ToList();

            item.Lessons = new List<UILesson>();

            UIAuditoryComparer auditoryComparer = new UIAuditoryComparer();
            UITeacherComparer teacherComparer = new UITeacherComparer();

            //объединение каждой группы в один предмет
            foreach (IGrouping<UILesson, UILesson> group in lessonsGroups)
            {
                if (group.Count() == 1)
                {
                    item.Lessons.Add(group.First());
                }
                else if (group.Count()>1)
                {
                    UILesson curLesson = group.ElementAt(0);

                    for (int i = 1; i < group.Count(); i++)
                    {
                        curLesson.Auditories.AddRange(group.ElementAt(i).Auditories.Except(curLesson.Auditories, auditoryComparer).ToList());
                        curLesson.Teachers.AddRange(group.ElementAt(i).Teachers.Except(curLesson.Teachers, teacherComparer).ToList());
                    }

                    item.Lessons.Add(curLesson);

                }
            }

            return item;
        }

        
        /// <summary>
        /// Компаратор занятий
        /// </summary>
        private class UILessonComparer : IEqualityComparer<UILesson>
        {
            public bool Equals(UILesson x, UILesson y)
            {
                if (x.Name == y.Name && x.Time.Start == y.Time.Start && x.Time.End == y.Time.End && x.Type == y.Type)
                {
                    if (x.Date is UIDate && y.Date is UIDate)
                    {
                        UIDate one = x.Date as UIDate;
                        UIDate two = y.Date as UIDate;
                        if (one.Start == two.Start && one.End == two.End && one.Week == two.Week && one.Weekday == two.Weekday)
                        {
                            return true;
                        }
                    }
                    else if (x.Date is string && y.Date is string && (string)(x.Date)== (string)(y.Date))
                    {
                        return true;
                    }
                }
                return false;
            }

            public int GetHashCode(UILesson obj)
            {
                string result = obj.Name + obj.Time.Start + obj.Time.End + obj.Type;
                if (obj.Date is UIDate)
                {
                    UIDate one = obj.Date as UIDate;
                    result += one.Start + one.End + one.Week + one.Weekday;
                }
                else if (obj.Date is string)
                {
                    result += (string)(obj.Date);
                }
                return result.GetHashCode();
            }
        }


        /// <summary>
        /// Компаратор аудиторий
        /// </summary>
        private class UIAuditoryComparer : IEqualityComparer<UIAuditory>
        {
            public bool Equals(UIAuditory x, UIAuditory y)
            {
                if (x.Address == y.Address && x.Name == y.Name) return true;
                return false;
            }

            public int GetHashCode(UIAuditory obj)
            {
                return (obj.Address + obj.Name).GetHashCode();
            }
        }

        /// <summary>
        /// Компаратор преподавателей
        /// </summary>
        private class UITeacherComparer : IEqualityComparer<UITeacher>
        {
            public bool Equals(UITeacher x, UITeacher y)
            {
                if (x.Name == y.Name) return true;
                return false;
            }

            public int GetHashCode(UITeacher obj)
            {
                return obj.Name.GetHashCode();
            }
        }
    }
}