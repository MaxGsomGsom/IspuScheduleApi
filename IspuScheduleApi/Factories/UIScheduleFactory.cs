using System.Linq;
using Core.Domain;
using IspuScheduleApi2.Models;

namespace IspuScheduleApi2.Factories
{
    public static class UIScheduleFactory
    {
        public static UISchedule Init(GroupSchedule instance)
        {
            var item = new UISchedule();

            item.Name = instance.Name;
            item.Days = instance.Days.Select(UITrainingDayFactory.Init).ToList();

            return item;
        }
    }
}