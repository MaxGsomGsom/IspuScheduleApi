﻿using Core.Domain;
using IspuScheduleApi2.Models;

namespace IspuScheduleApi2.Factories
{
    /// <summary>
    ///     Фабрика для создания UI-модели "Группа"
    /// </summary>
    public static class UIGroupFactory
    {
        public static UIGroup Init(Group instance)
        {
            var item = new UIGroup();
            item.Id = instance.Id;
            item.Name = instance.Name;

            return item;
        }
    }
}