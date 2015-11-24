using System.Linq;
using Core.Domain;
using IspuScheduleApi.Models;

namespace IspuScheduleApi.Factories
{
    public static class UITrainingDayFactory
    {
        public static UITrainingDay Init(TrainingDay instance)
        {
            var item = new UITrainingDay();

            item.WeekDay = instance.WeekDay;
            item.Lessons = instance.Lessons.Select(UILesssonFactory.Init).ToList();

            return item;
        }
    }
}