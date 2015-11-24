using System;
using Newtonsoft.Json;

namespace IspuScheduleApi.Models
{
    /// <summary>
    ///     UI модель "Факультет"
    /// </summary>
    public class UIFaculty
    {
        [JsonProperty("faculty_name", Order = 0)]
        public String Name { get; set; }

        [JsonProperty("faculty_id", Order = 1)]
        public int? Id { get; set; }

        [JsonProperty("date_start", Order = 2)]
        public DateTime? Start { get; set; }

        [JsonProperty("date_end", Order = 3)]
        public DateTime? End { get; set; }
    }
}