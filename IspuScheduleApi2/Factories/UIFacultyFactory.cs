﻿using Core;
using Core.Domain;
using IspuScheduleApi2.Models;
using System.Linq;

namespace IspuScheduleApi2.Factories
{
    /// <summary>
    /// Фабрика для создания UI-модели
    /// </summary>
    public static class UIFacultyFactory
    {
        public static UIFaculty Init(Faculty instance)
        {
            var item = new UIFaculty();

            item.Name = instance.Name;
            item.Groups = DATA.GetGroups(instance.Id).Select(UIGroupFactory.Init).ToList();

            return item;
        }
    }
}