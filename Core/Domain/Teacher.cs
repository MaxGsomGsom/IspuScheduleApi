namespace Core.Domain
{
    /// <summary>
    ///     Преподаватель
    /// </summary>
    public class Teacher
    {
        /// <summary>
        ///     ФИО
        /// </summary>
        public string Name { get; set; }

        public static Teacher Generate(DAL.Models.Tutor instance)
        {
            var item = new Teacher();
            item.Name = string.Format("{0}", instance.Name);

            return item;
        }
    }
}