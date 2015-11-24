using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using IspuScheduleApi.Models;

namespace IspuScheduleApi.Factories
{
    /// <summary>
    ///     Фабрика для создания UI-модели "Группы"
    /// </summary>
    public static class UIGroupsFactory
    {
        public static UIGroups Init(IEnumerable<Group> instances)
        {
            return new UIGroups {Groups = instances.Select(UIGroupFactory.Init).ToList()};
        }
    }
}