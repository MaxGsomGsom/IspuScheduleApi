using System.Collections.Generic;
using Newtonsoft.Json;

namespace IspuScheduleApi2.Models
{
    /// <summary>
    ///     UI-модель "Группы"
    /// </summary>
    public class UIGroups
    {
        [JsonProperty(PropertyName = "groups")] public List<UIGroup> Groups;
    }
}