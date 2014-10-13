namespace Core.Domain
{
    /// <summary>
    ///     Аудитория
    /// </summary>
    public class Auditory
    {
        /// <summary>
        ///     Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Адрес
        /// </summary>
        public string Address { get; set; }

        public static Auditory Generate(DAL.Models.Audience instance)
        {
            var item = new Auditory();
            item.Name = string.Format("{0}{1}", instance.Building.Title, instance.Number);
            item.Address = instance.Building.Address;

            return item;
        }
    }
}