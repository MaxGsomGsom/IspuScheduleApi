using System.Web.Http;
using Core;
using IspuScheduleApi2.Factories;
using IspuScheduleApi2.Models;

namespace IspuScheduleApi2.Controllers
{
    public class ScheduleController : ApiController
    {
        /// <summary>
        ///     Возвращает список факультетов
        /// </summary>
        /// <returns></returns>
        public UIFaculties get_faculties()
        {
            return UIFacultiesFactory.Init(DATA.GetFaculties());
        }

        /// <summary>
        ///     Возвращает список групп по указанному идентификатору факультета
        /// </summary>
        /// <param name="faculty_id">Идентификатор факультета</param>
        /// <returns></returns>
        public UIGroups get_groups(int faculty_id)
        {
            return UIGroupsFactory.Init(DATA.GetGroups(faculty_id));
        }

        /// <summary>
        ///     Возвращает рассписание для указаной группы
        /// </summary>
        /// <param name="group_id">Идентификатор группы</param>
        /// <returns></returns>
        public UISchedule get_schedule(int group_id)
        {
            return UIScheduleFactory.Init(DATA.GetSchedule(group_id));
        }
    }
}