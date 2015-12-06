using Core.Domain;
using IspuScheduleApi2.Models;

namespace IspuScheduleApi2.Factories
{
    public static class UIAuditoryFactory
    {
        /// <summary>
        /// Фабрика для создания UI-модели
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static UIAuditory Init(Auditory instance)
        {
            var item = new UIAuditory();

            item.Name = instance.Name;
            item.Address = instance.Address;
            item.LonLat = instance.LonLat;

            return item;
        }
    }
}