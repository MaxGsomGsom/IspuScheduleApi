using System.Collections.Generic;
using Newtonsoft.Json;

namespace IspuScheduleApi.Models
{
    /// <summary>
    ///     UI-модель "Учебный день"
    /// </summary>
    public class UITrainingDay
    {
        /// <summary>
        ///     День недели
        /// </summary>
        [JsonProperty("weekday")]
        public int WeekDay { get; set; }

        /// <summary>
        ///     Список занятий
        /// </summary>
        [JsonProperty("lessons")]
        public List<UILesson> Lessons { get; set; }
    }
}