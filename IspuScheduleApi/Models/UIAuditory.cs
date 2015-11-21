using Newtonsoft.Json;

namespace IspuScheduleApi.Models
{
    /// <summary>
    ///     UI-модель  "Аудитория"
    /// </summary>
    public class UIAuditory
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("addr")]
        public string Address { get; set; }
    }
}