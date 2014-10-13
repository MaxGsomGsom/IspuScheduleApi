using Core.Domain;
using IspuScheduleApi.Models;

namespace IspuScheduleApi.Factories
{
    public static class UIAuditoryFactory
    {
        public static UIAuditory Init(Auditory instance)
        {
            var item = new UIAuditory();

            item.Name = instance.Name;
            item.Address = instance.Address;

            return item;
        }
    }
}