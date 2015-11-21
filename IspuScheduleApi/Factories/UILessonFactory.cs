using System.Linq;
using Core.Domain;
using IspuScheduleApi.Models;

namespace IspuScheduleApi.Factories
{
    public static class UILessonFactory
    {
        /// <summary>
        /// Фабрика для создания UI-модели
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="weekday"></param>
        /// <returns></returns>
        public static UILesson Init(Lesson instance, int weekday)
        {
            var item = new UILesson();

            item.Name = instance.Name;
            item.Type = instance.TypeString;


            item.Time = new UITime();
            item.Time.Start = instance.TimeStart.Value.ToShortTimeString();
            item.Time.End = instance.TimeEnd.Value.ToShortTimeString();

            if (instance.Dates.Count > 0)
            {
                item.Date = instance.Dates.First().ToShortDateString();
            }
            else
            {
                item.Date = new UIDate();
                (item.Date as UIDate).Start = instance.DateStart.Value.ToShortDateString();
                (item.Date as UIDate).End = instance.DateEnd.Value.ToShortDateString();
                (item.Date as UIDate).Week = instance.Parity.Value;
                (item.Date as UIDate).Weekday = weekday;
            }


            item.Teachers = instance.Teachers != null ? instance.Teachers.Select(UITeacherFactory.Init).ToList() : null;
            item.Auditories = instance.Auditories != null ? instance.Auditories.Select(UIAuditoryFactory.Init).ToList() : null;

            return item;
        }
    }
}