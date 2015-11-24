using System.Collections.Generic;
using System.Linq;
using Core.Domain;
using IspuScheduleApi2.Models;

namespace IspuScheduleApi2.Factories
{
    public static class UIFacultiesFactory
    {
        public static UIFaculties Init(IEnumerable<Faculty> instances)
        {
            return new UIFaculties {Faculties = instances.Select(UIFacultyFactory.Init).ToList()};
        }
    }
}