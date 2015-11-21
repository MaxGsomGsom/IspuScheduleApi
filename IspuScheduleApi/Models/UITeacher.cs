using Newtonsoft.Json;

namespace IspuScheduleApi.Models
{
    /// <summary>
    ///     UI-модель "Преподаватель"
    /// </summary>
    public class UITeacher
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}