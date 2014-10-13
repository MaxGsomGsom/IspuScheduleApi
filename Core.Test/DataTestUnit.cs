using System.Linq;
using Core.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test
{
    [TestClass]
    public class DataTestUnit
    {
        #region Faculties testing

        [TestMethod]
        public void FacultyTest()
        {
            var items = DATA.GetFaculties();

            Assert.AreNotEqual(items, null, "Коллекция пуста");
            Assert.AreEqual(items.Count(), 6, "Количество факультетов не соответсвует действительности");
        }

        #endregion

        #region Groups testing

        [TestMethod]
        public void GroupsTest()
        {
            var items = DATA.GetFaculties();
            foreach (var item in items)
            {
                var groups = DATA.GetGroups(item.Id);

                Assert.AreNotEqual(groups, null, "Нет групп в факультете");
                Assert.AreNotEqual(groups.Count(), 0, "Нет групп в факультете");

                foreach (var group in groups)
                {
                    GroupTest(group);
                }
            }
        }

        public void GroupTest(Group group)
        {
            Assert.IsTrue(group.Id > 0, "Не определён идентификатор группы");
            Assert.IsTrue(!string.IsNullOrEmpty(group.Name), "Не определо имя группы");
        }

        #endregion

        #region Schedule testing

        [TestMethod]
        public void ScheduleTesting()
        {
            var faculties = DATA.GetFaculties();

            foreach (var faculty in faculties)
            {
                foreach (var group in DATA.GetGroups(faculty.Id))
                {
                    var schedule = DATA.GetSchedule(group.Id);

                    Assert.IsFalse(schedule == null, string.Format("Нет рассписания для группы. {0} | Id: {1}", group.Name, group.Id));
                    Assert.AreNotEqual(schedule.Days.Count, "Нет рассписания для группы");
                }
            }
        }

        public void TestDay(TrainingDay day)
        {
            Assert.IsTrue(day.WeekDay > 0 && day.WeekDay < 8, "Неверный день недели");

            if (!day.Lessons.Any()) return;

            foreach (var lesson in day.Lessons)
                TestLessong(lesson);
        }

        public void TestLessong(Lesson lesson)
        {
            Assert.IsFalse(string.IsNullOrEmpty(lesson.Name), "Не указано наименование предмета");
            Assert.IsTrue(lesson.Type >= 0 && lesson.Type < 8, "Неверный тип предмета");
            Assert.AreNotEqual(lesson.TimeStart, null, "Не указано время начала занятий");
            Assert.AreNotEqual(lesson.TimeEnd, null, "Не указано время окончания занятий");
            Assert.AreNotEqual(lesson.DateStart, null, "Не указана дата начала занятий");
            Assert.AreNotEqual(lesson.DateEnd, null, "Не указана дата окончания занятий");
            Assert.IsTrue(lesson.Parity == 1 || lesson.Parity == 2, "Неверная чётность");
        }

        #endregion
    }
}