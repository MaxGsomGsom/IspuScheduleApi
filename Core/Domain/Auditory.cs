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

        /// <summary>
        ///     Координаты
        /// </summary>
        public string LonLat { get; set; }


        public static Auditory Generate(DAL.Models.Audience instance)
        {
            var item = new Auditory();
            item.Name = string.Format("{0}{1}", instance.Building.Title, instance.Number);
            item.Address = instance.Building.Address;

            switch (instance.Building.Title)
            {
                case "А": item.LonLat = "57.001343, 40.940781"; break;
                case "Б": item.LonLat = "57.001194, 40.942757"; break;
                case "В": item.LonLat = "57.002313, 40.942123"; break;
                case "С": item.LonLat = "57.001071, 40.939779"; break;
                case "Г": item.LonLat = "57.000305, 40.955571"; break;
                case "М": item.LonLat = "57.002336, 40.934735"; break;
                case "Д": item.LonLat = "57.020685, 40.962397"; break;
                case "Е": item.LonLat = "56.993477, 40.979393"; break;
                case "К": item.LonLat = "57.001987, 40.940427"; break;
                case "Л": item.LonLat = "57.002262, 40.938712"; break;
                default: item.LonLat = "57.001194, 40.942757"; break;
            }

            return item;
        }
    }
}