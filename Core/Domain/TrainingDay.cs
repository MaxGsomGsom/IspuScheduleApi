using System.Collections.Generic;
using System.Linq;

namespace Core.Domain
{
    /// <summary>
    ///     Учебный день
    /// </summary>
    public class TrainingDay
    {
        /// <summary>
        ///     День недели
        /// </summary>
        public int WeekDay { get; set; }

        /// <summary>
        ///     Список занятий
        /// </summary>
        public List<Lesson> Lessons { get; set; }

        public static TrainingDay Generate(List<DAL.Models.TimeTable> instances) // передаём строки, относящиеся к только к этому дню недели, с учётом чётности
        {
            if (instances == null || !instances.Any())
                return null;

            var instance = instances.First();

            var item = new TrainingDay();
            
            item.WeekDay = instance.WeekDayId ?? 0; // берём идентификатор, совпадает с номером дня недели.
            item.Lessons = instances.GroupBy(el => el.TemeId).Select(el => Lesson.Generate(el.ToList())).ToList();

            return item;
        }
    }
}