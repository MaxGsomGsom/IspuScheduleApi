using System;

namespace Core.Domain
{
    /// <summary>
    ///     Факультет
    /// </summary>
    public class Faculty
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Дата начала занятий
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        ///     Дата окончания занятий
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        ///     Фабричный метод генерации бизенс-объекта
        /// </summary>
        /// <param name="instance">EF-объект</param>
        /// <returns></returns>
        public static Faculty Generage(DAL.Models.Subdivision instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            var item = new Faculty();
            item.Id = instance.Id;
            item.Name = instance.Title;
            item.Start = null;
            item.Start = null;

            return item;
        }
    }
}