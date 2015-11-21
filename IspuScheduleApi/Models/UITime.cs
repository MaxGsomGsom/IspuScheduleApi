using System.Collections.Generic;
using Newtonsoft.Json;

namespace IspuScheduleApi.Models
{
    /// <summary>
    /// UI-модель "Время"
    /// </summary>
    public class UITime
    {
        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }
    }
}