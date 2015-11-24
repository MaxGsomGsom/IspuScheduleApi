using System.Collections.Generic;
using Newtonsoft.Json;

namespace IspuScheduleApi2.Models
{
    public class UISchedule
    {
        /// <summary>
        ///     Имя группы
        /// </summary>
        [JsonProperty("group_name")]
        public string Name { get; set; }

        /// <summary>
        ///     Учебные дни
        /// </summary>
        [JsonProperty("days")]
        public List<UITrainingDay> Days { get; set; }
    }
}