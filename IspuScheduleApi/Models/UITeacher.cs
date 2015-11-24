using Newtonsoft.Json;

namespace IspuScheduleApi2.Models
{
    /// <summary>
    ///     UI-модель "Преподаватель"
    /// </summary>
    public class UITeacher
    {
        [JsonProperty("teacher_name")]
        public string Name { get; set; }
    }
}