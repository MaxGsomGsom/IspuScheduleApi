using Core.Domain;
using IspuScheduleApi.Models;

namespace IspuScheduleApi.Factories
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