using System.Collections.Generic;
using Newtonsoft.Json;

namespace IspuScheduleApi2.Models
{
    /// <summary>
    /// UI-модель "Расписание"
    /// </summary>
    public class UISchedule
    {

        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("abbr")]
        public string Abbr { get; set; }

        [JsonProperty("faculties")]
        public List<UIFaculty> Faculties { get; set; }
    }
}