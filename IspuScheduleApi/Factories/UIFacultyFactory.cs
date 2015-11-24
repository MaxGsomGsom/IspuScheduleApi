using Core.Domain;
using IspuScheduleApi2.Models;

namespace IspuScheduleApi2.Factories
{
    public static class UIFacultyFactory
    {
        public static UIFaculty Init(Faculty instance)
        {
            var item = new UIFaculty();

            item.Id = instance.Id;
            item.Name = instance.Name;
            item.Start = instance.Start;
            item.End = instance.End;

            return item;
        }
    }
}