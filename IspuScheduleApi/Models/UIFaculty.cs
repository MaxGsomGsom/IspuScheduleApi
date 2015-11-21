using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IspuScheduleApi.Models
{
    /// <summary>
    ///     UI модель "Факультет"
    /// </summary>
    public class UIFaculty
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("groups")]
        public List<UIGroup> Groups { get; set; }
    }
}