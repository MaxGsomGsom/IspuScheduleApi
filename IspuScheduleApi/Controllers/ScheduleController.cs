using System.Web.Http;
using Core;
using IspuScheduleApi.Factories;
using IspuScheduleApi.Models;

namespace IspuScheduleApi.Controllers
{
    public class ScheduleController : ApiController
    {

        /// <summary>
        /// Получение всего расписания
        /// </summary>
        /// <returns></returns>
        public UISchedule get_schedule()
        {
            return UIScheduleFactory.Init();
        }

    }
}