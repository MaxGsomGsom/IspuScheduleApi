using Newtonsoft.Json;

namespace IspuScheduleApi.Models
{
    /// <summary>
    ///     UI-модель  "Аудитория"
    /// </summary>
    public class UIAuditory
    {
        [JsonProperty("auditory_name")]
        public string Name { get; set; }

        [JsonProperty("auditory_address")]
        public string Address { get; set; }
    }
}