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
                        curLesson.Auditories.AddRange(group.ElementAt(i).Auditories);
                        curLesson.Teachers.AddRange(group.ElementAt(i).Teachers);
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
                if (x.Name == y.Name && x.Time == y.Time && x.Type == y.Type)
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
                    else if (x.Date is string && y.Date is string && x.Date==y.Date)
                    {
                        return true;
                    }
                }
                return false;
            }

            public int GetHashCode(UILesson obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}