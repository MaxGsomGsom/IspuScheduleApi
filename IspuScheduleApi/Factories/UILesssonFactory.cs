using System.Linq;
using Core.Domain;
using IspuScheduleApi.Models;

namespace IspuScheduleApi.Factories
{
    public static class UILesssonFactory
    {
        public static UILesson Init(Lesson instance)
        {
            var item = new UILesson();

            item.Name = instance.Name;
            item.Type = instance.Type;
            item.TimeStart = instance.TimeStart.Value.ToShortTimeString();
            item.TimeEnd = instance.TimeEnd.Value.ToShortTimeString();
            item.DateStart = instance.DateStart.Value.ToShortDateString();
            item.DateEnd = instance.DateEnd.Value.ToShortDateString();
            item.Parity = instance.Parity;
            item.Teachers = instance.Teachers != null ? instance.Teachers.Select(UITeacherFactory.Init).ToList() : null;
            item.Auditories = instance.Auditories != null ? instance.Auditories.Select(UIAuditoryFactory.Init).ToList() : null;

            return item;
        }
    }
}