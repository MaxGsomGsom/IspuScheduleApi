using Core;
using Core.Domain;
using IspuScheduleApi.Models;
using System.Linq;
using System.Collections.Generic;

namespace IspuScheduleApi.Factories
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

            item.Lessons = new List<UILesson>();
            GroupSchedule sched = DATA.GetSchedule(instance.Id);

            foreach (TrainingDay day in sched.Days)
            {
                int weekday = day.WeekDay;
                foreach (Lesson lesson in day.Lessons)
                {
                    item.Lessons.Add(UILessonFactory.Init(lesson, weekday));
                }
            }

            return item;
        }
    }
}