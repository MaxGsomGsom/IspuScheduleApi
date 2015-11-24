using Core.Domain;
using IspuScheduleApi2.Models;

namespace IspuScheduleApi2.Factories
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