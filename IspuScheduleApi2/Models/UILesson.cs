using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IspuScheduleApi2.Models
{
    /// <summary>
    ///     UI-модель "Предмет"
    /// </summary>
    public class UILesson
    {
        /// <summary>
        ///     Наименование предмета
        /// </summary>
        [JsonProperty("subject")]
        public string Name { get; set; }

        /// <summary>
        ///     Тип
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Время 
        /// </summary>
        [JsonProperty("time")]
        public UITime Time { get; set; }

        /// <summary>
        ///     Даты
        /// </summary>
        //[JsonProperty("date")]
        //public UIDate DatePeriodic { get; set; }

        /// <summary>
        ///     Отдельные даты занятий
        /// </summary>
        [JsonProperty("date")]
        public object Date { get; set; }

        /// <summary>
        ///     Аудитории
        /// </summary>
        [JsonProperty("audiences")]
        public List<UIAuditory> Auditories { get; set; }

        /// <summary>
        ///     Преподаватели
        /// </summary>
        [JsonProperty("teachers")]
        public List<UITeacher> Teachers { get; set; }
    }
}