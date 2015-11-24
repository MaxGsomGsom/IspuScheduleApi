using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IspuScheduleApi.Models
{
    /// <summary>
    ///     UI-модель "Предмет"
    /// </summary>
    public class UILesson
    {
        /// <summary>
        ///     Наименование предмета
        /// </summary>
        [JsonProperty("subject", Order = 0)]
        public string Name { get; set; }

        /// <summary>
        ///     Тип
        /// </summary>
        [JsonProperty("type", Order = 1)]
        public int Type { get; set; }

        /// <summary>
        ///     Время начала
        /// </summary>
        [JsonProperty("time_start", Order = 2)]
        public string TimeStart { get; set; }

        /// <summary>
        ///     Время окончания
        /// </summary>
        [JsonProperty("time_end", Order = 3)]
        public string TimeEnd { get; set; }

        /// <summary>
        ///     Дата начала занятий
        /// </summary>
        [JsonProperty("date_start", Order = 5)]
        public string DateStart { get; set; }

        /// <summary>
        ///     Дата окончания занятий
        /// </summary>
        [JsonProperty("date_end", Order = 6)]
        public string DateEnd { get; set; }

        /// <summary>
        ///     Отдельные даты занятий
        /// </summary>
        [JsonProperty("dates", Order = 7)]
        public List<DateTime> Dates { get; set; }

        /// <summary>
        ///     Чётность
        /// </summary>
        [JsonProperty("parity", Order = 4)]
        public int? Parity { get; set; }

        /// <summary>
        ///     Преподаватели
        /// </summary>
        [JsonProperty("teachers", Order = 8)]
        public List<UITeacher> Teachers { get; set; }

        /// <summary>
        ///     Аудитории
        /// </summary>
        [JsonProperty("auditories", Order = 9)]
        public List<UIAuditory> Auditories { get; set; }
    }
}