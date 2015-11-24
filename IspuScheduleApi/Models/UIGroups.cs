using System.Collections.Generic;
using Newtonsoft.Json;

namespace IspuScheduleApi.Models
{
    /// <summary>
    ///     UI-модель "Группы"
    /// </summary>
    public class UIGroups
    {
        [JsonProperty(PropertyName = "groups")] public List<UIGroup> Groups;
    }
}