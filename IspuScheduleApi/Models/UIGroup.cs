using Newtonsoft.Json;

namespace IspuScheduleApi.Models
{
    /// <summary>
    ///     UI-модель "Группа"
    /// </summary>
    public class UIGroup
    {
        [JsonProperty(PropertyName = "group_id", Order = 1)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "group_name", Order = 0)]
        public string Name { get; set; }
    }
}