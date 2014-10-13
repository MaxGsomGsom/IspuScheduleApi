using System.Collections.Generic;
using System.Linq;

namespace Core.Domain
{
    /// <summary>
    ///     Рассписание для группы
    /// </summary>
    public class GroupSchedule
    {
        /// <summary>
        ///     Имя группы
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Учебные дни
        /// </summary>
        public List<TrainingDay> Days { get; set; }

        public static GroupSchedule Generate(List<DAL.Models.TimeTable> instances)
        {
            if (instances == null || !instances.Any())
                return null;

            var instance = instances.First();

            var item = new GroupSchedule();
            if (instance.SubGroup != null)
                item.Name = Group.Generate(instance.SubGroup).Name;

            item.Days = instances.GroupBy(el => el.WeekNumber*10 + el.WeekDayId).Select(el => TrainingDay.Generate(el.ToList())).ToList();

            return item;
        }
    }
}