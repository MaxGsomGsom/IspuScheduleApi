namespace Core.Domain
{
    /// <summary>
    ///     Группа
    /// </summary>
    public class Group
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Наименование
        /// </summary>
        public string Name { get; set; }

        public static Group Generate(DAL.Models.SubGroup instance)
        {
            var item = new Group();

            item.Id = instance.Id;
            item.Name = string.Format("{0}-{1}{2}", instance.Course, instance.Groups.Name, instance.Name);

            return item;
        }
    }
}