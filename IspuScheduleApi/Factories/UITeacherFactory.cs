using Core.Domain;
using IspuScheduleApi.Models;

namespace IspuScheduleApi.Factories
{
    public static class UITeacherFactory
    {
        public static UITeacher Init(Teacher instance)
        {
            var item = new UITeacher();
            item.Name = instance.Name;

            return item;
        }
    }
}