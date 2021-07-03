
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;


namespace CG.Specflow.Test.Steps
{
   [Binding]
    public class MSDynmicsUserLoginSteps
    {
        public IWebDriver driver = null;
        
        public  MSDynmicsUserLoginSteps()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [Given(@"I am on the Dynamic365 login page")]
        public void GivenIAmOnTheDynamicLoginPage()
        {
         
           driver.Url = "https://lcs.dynamics.com/Logon/Index";
        

        }
       
        [When(@"I click on SignIn button")]
        public void WhenIClickOnSignInButton()
        {

           driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/a/div/span[1]")).Click();
        }


        [When(@"I enter the username as ""(.*)"" and password as '(.*)'")]
        public void WhenIEnterTheUsernameAndPassword(string username, string password)
        {
           driver.FindElement(By.XPath("//input[@name='loginfmt']")).SendKeys(username);
           driver.FindElement(By.XPath("//*[@id='idSIButton9']")).Click();
            Thread.Sleep(2000);
           driver.FindElement(By.XPath("//*[@id='i0118']")).SendKeys(password);

        }

        [When(@"Submit those details")]
        public void WhenSubmitThoseDetails()
        {

           driver.FindElement(By.XPath("//input[@id='idSIButton9'] ")).Click();

           driver.FindElement(By.XPath("//input[@id='idSIButton9'] ")).Click();
            Thread.Sleep(5000);
        }

        [Given(@"I have logged in")]
        [Then(@"I have logged in")]
        public void ThenIAmLoggedIn()
        {
            string pageTitle =driver.FindElement(By.XPath("/html//a[@id='lcsText']")).Text;
            Console.WriteLine("The Page Title is " + pageTitle);

            if (pageTitle.Equals("Lifecycle Services"))
            {
                Assert.Pass("Successfully Logged in ");
            
            }
            else
            {
                Assert.Fail("NotLogged in ");

            }

        }



        [When(@"I enter the valid username ""(.*)"" and wrong password '(.*)'")]
        public void WhenIEnterTheValidUsernameAndWrongPassword(string username, string password)
        {
           driver.FindElement(By.XPath("//input[@name='loginfmt']")).SendKeys(username);
           driver.FindElement(By.XPath("//*[@id='idSIButton9']")).Click();
            Thread.Sleep(2000);
           driver.FindElement(By.XPath("//*[@id='i0118']")).SendKeys(password);
        }

        [Then(@"error message is displayed")]
        public void ThenErrorMessageIsDisplayed()
        {
           string msg=driver.FindElement(By.XPath("//*[@id='passwordError']")).Text;
          
           Console.WriteLine(msg);  

        }

        [After]
        public void tearDown()
        {

           driver.Quit();
        }


    }
}
