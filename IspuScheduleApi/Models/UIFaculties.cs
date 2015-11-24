using System.Collections.Generic;
using Newtonsoft.Json;

namespace IspuScheduleApi.Models
{
    /// <summary>
    ///     UI модель "Факультеты"
    /// </summary>
    public class UIFaculties
    {
        [JsonProperty("faculties")] public List<UIFaculty> Faculties;
    }
}