using Newtonsoft.Json;
using System.Collections.Generic;

namespace IspuScheduleApi.Models
{
    /// <summary>
    ///     UI-модель "Группа"
    /// </summary>
    public class UIGroup
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lessons")]
        public List<UILesson> Lessons { get; set; }
    }
}