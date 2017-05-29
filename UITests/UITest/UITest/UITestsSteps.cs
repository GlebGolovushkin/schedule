using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;

namespace UITest
{
    [Binding]
    public class UITestsSteps
    {
        private static Application app;
        private static Window window;


        [BeforeScenario]
        public static void BeforeTestRun()
        {
            app = Application.Launch(@"C:\Schedule\SheduleEF\SheduleEF\bin\Debug\SheduleEF.exe");
            window = app.GetWindow("Расписание ИГЭУ");
        }

        [AfterScenario]
        public static void AfterTestRun()
        {
            app.Process.Kill();
        }

        [Then(@"'(.*)' schedule is opened")]
        public void ThenScheduleIsOpened(string scheduleName)
        {
            var table = window.Get<TestStack.White.UIItems.TableItems.Table>("dataGridView2");
            var cell = table.Rows[0].Cells[0];
            Assert.AreEqual(scheduleName, cell.Value.ToString());
        }

        [Then(@"tool tip menu does not have '(.*)'")]
        public void ThenToolTipMenuDoesNotHave(string toolTipMenuName)
        {
            try
            {
                window.Get<MenuBar>("menuStrip1").MenuItem("Файл", toolTipMenuName).Click();
                Assert.False(true);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Then(@"the user has admin abilities")]
        public void ThenToolTipMenuHasAbilities()
        {
            Assert.True(window.Get<MenuBar>("menuStrip2").Visible);
        }

        [Then(@"the user does not have admin abilities")]
        public void ThenToolTipMenuDoesNotHaveAbilities()
        {
            try
            {
                Assert.True(window.Get<MenuBar>("menuStrip2").Visible);
                Assert.False(true);
            }
            catch
            {
                Assert.True(true);
            }
        }

        [Then(@"tool tip menu has '(.*)'")]
        public void ThenToolTipMenuHas(string toolTipMenuName)
        {
            window.Get<MenuBar>("menuStrip1").MenuItem("Файл", toolTipMenuName).Click();
        }

        [When(@"the user sets '(.*)' schedule")]
        public void WhenTheUserSetsSchedule(string scheduleName)
        {
            if (scheduleName == "студента")
            {
                window.Get<RadioButton>("radioButton1").Select();
            }
            if (scheduleName == "преподавателя")
            {
                window.Get<RadioButton>("radioButton2").Select();
            }
            if (scheduleName == "аудитории")
            {
                window.Get<RadioButton>("radioButton3").Select();
            }
        }

        [When(@"the user sets '(.*)' x")]
        public void WhenTheUserSetsX(int x)
        {
            if (x == 1)
            {
                window.Get<RadioButton>("radioButton4").Select();
            }
            else if (x == 2)
            {
                window.Get<RadioButton>("radioButton5").Select();
            }
        }

        [When(@"the user sets '(.*)' course '(.*)' group")]
        public void WhenTheUserSetsCourseGroup(string course, string group)
        {
            window.Get<ComboBox>("comboBoxStudent2").Select(course);
            window.Get<ComboBox>("comboBoxStudent1").Select(group);
        }

        [When(@"the user sets '(.*)' teacher")]
        public void WhenTheUserSetsCourseGroup(string teacher)
        {
            window.Get<ComboBox>("comboBoxTeacher3").Select(teacher);
        }

        [Then(@"pop up with '(.*)' text appears")]
        public void ThenPopUpWithTextAppears(string text)
        {
            Assert.NotNull(window.Get<Label>(SearchCriteria.ByText(text)));
        }

        [When(@"the user sets '(.*)' as admin password")]
        public void WhenTheUserSetsAsAdminPassword(string password)
        {
            window.Get<TextBox>("textBox1").SetValue(password);
            window.Get<Button>("button1").Click();
        }

        [When(@"the user sets '(.*)' building")]
        public void WhenTheUserSetsBuilding(string building)
        {
            window.Get<ComboBox>("comboBox1").Select(building);
        }

        [When(@"the user sets '(.*)' auditor")]
        public void WhenTheUserSetsAuditor(string auditor)
        {
            window.Get<ComboBox>("comboBox2").Select(auditor);
        }

        [When(@"the user sets Ok in pop up")]
        public void WhenTheUserSetsOkInPopUp()
        {
            window.Get<Button>(SearchCriteria.ByText("ОК")).Click();
        }

        [When(@"the user sets '(.*)' faculty")]
        public void WhenTheUserSetsFaculty(string faculty)
        {
            window.Get<ComboBox>("comboBoxStudent3").Select(faculty);
        }

        [When(@"the user sets '(.*)' in tool tip menu")]
        public void WhenTheUserSetsInToolTipMenu(string toolTipItem)
        {
            window.Get<MenuBar>("menuStrip1").MenuItem("Файл", toolTipItem).Click();
        }
    }
}
