using System.Linq;
using Core.Domain;
using IspuScheduleApi2.Models;
using Core;

namespace IspuScheduleApi2.Factories
{
    /// <summary>
    /// Фабрика для создания UI-модели
    /// </summary>
    public static class UIScheduleFactory
    {
        public static UISchedule Init()
        {
            var item = new UISchedule();

            item.Name = "Ивановский Государственный Энергетический Университет";
            item.Abbr = "ИГЭУ";
            item.Faculties = DATA.GetFaculties().Select(UIFacultyFactory.Init).ToList();


            return item;
        }
    }
}