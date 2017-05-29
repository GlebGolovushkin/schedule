using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using NUnit.Framework;

namespace WebUITests
{
    [Binding]
    public class WebTestsSteps
    {
        IWebDriver driver;

        [BeforeScenario]
        public void BefoureScenario()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://192.168.137.1:50004/Sheadule");
            driver.Url = "http://192.168.137.1:50004/Sheadule";
            string title = driver.Title;
            Assert.AreEqual("asd", title);
        }

        [When(@"the user sets '(.*)' schedule")]
        public void WhenTheUserSetsSchedule(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user sets '(.*)' x")]
        public void WhenTheUserSetsX(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user sets '(.*)' faculty")]
        public void WhenTheUserSetsFaculty(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user sets '(.*)' course '(.*)' group")]
        public void WhenTheUserSetsCourseGroup(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user sets '(.*)' teacher")]
        public void WhenTheUserSetsTeacher(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user sets '(.*)' building")]
        public void WhenTheUserSetsBuilding(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user sets '(.*)' auditor")]
        public void WhenTheUserSetsAuditor(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"'(.*)' schedule is opened")]
        public void ThenScheduleIsOpened(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
