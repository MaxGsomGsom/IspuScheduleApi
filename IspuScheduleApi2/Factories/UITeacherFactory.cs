using Core.Domain;
using IspuScheduleApi2.Models;

namespace IspuScheduleApi2.Factories
{
    public static class UITeacherFactory
    {
        /// <summary>
        /// Фабрика для создания UI-модели
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static UITeacher Init(Teacher instance)
        {
            var item = new UITeacher();
            item.Name = instance.Name;

            return item;
        }
    }
}