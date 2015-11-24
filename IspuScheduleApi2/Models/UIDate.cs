using System.Collections.Generic;
using Newtonsoft.Json;

namespace IspuScheduleApi2.Models
{
    /// <summary>
    /// UI-модель  "Дата"
    /// </summary>
    public class UIDate
    {
        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("weekday")]
        public int Weekday { get; set; }

        [JsonProperty("week")]
        public int Week { get; set; }
    }
}