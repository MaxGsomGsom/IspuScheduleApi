using Core.Domain;
using IspuScheduleApi2.Models;

namespace IspuScheduleApi2.Factories
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