
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;


namespace CG.Specflow.Test.Steps
{
    
    [Binding]
    public class ManageMethodologiesSteps
    {
        public IWebDriver driver;

        public ManageMethodologiesSteps()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        

        [When (@"I click on Manage methodologies")]
        public void GivenIClickOnManageMethodologies()
        {

           driver.FindElement(By.XPath("//*[@id='Homepage_1_ManageOrgTile']")).Click();
        }
        
        [When(@"I click on plus sign")]
        public void WhenIClickOnPlusSign()
        {
           driver.FindElement(By.XPath("//*[@id='MethodologyListForm_1_AddMethod'']")).Click();

        }

      

        [When(@"Enter Name as ""(.*)"" & Prodcut Name as ""(.*)"" on the new methodologies panel")]
        public void WhenEnterNameAsProdcutNameAsOnTheNewMethodologiesPanel(string methodName, string productName)
        {

           driver.FindElement(By.XPath("//*[@id='MethodologyDetailsSlider_2_MethodNameField_input']")).SendKeys(methodName);
           driver.FindElement(By.XPath("//*[@id='MethodologyDetailsSlider_3_Product_input']")).SendKeys(productName);
           
        }



        [When(@"Click on Confirm button")]
        public void WhenClickOnCofirm()
        {
           driver.FindElement(By.XPath("//*[@id='MethodologyDetailsSlider_3_SaveBtn']")).Click();

        }
        
      


        [Then(@"new methodologies as ""(.*)"" is created")]
        public void ThenNewMethodologiesAsIsCreated(string pageHeading)
        {
            string msg =driver.FindElement(By.XPath("//*[@id='form_3']/div[3]/div/div[4]/div[2]/h1")).Text;
            if (pageHeading.Equals(msg))
            {
                Console.WriteLine("Methodology is created");
            }
            else
            {
                Console.WriteLine("Methodology is not created");

            }

        }




        [When(@"I selected the ""(.*)""")]
        public void WhenISelectedThe(string methodologyName)
        {

           driver.FindElement(By.PartialLinkText(methodologyName)).Click();
            
        }

        [When(@"I click on Delete Methodology icon")]
        public void WhenIClickOnDeleteMethodologyIcon()
        {
           driver.FindElement(By.XPath("//*[@id='MethodologyListForm_2_DeleteMethod']")).Click();
        }

        [When(@"Click Yes on pop winodw")]
        public void WhenClinYesOnPopWinodw()
        {
           driver.FindElement(By.XPath("//button[@data-dyn-controlname='Yes']")).Click();
        }

        [Then(@"""(.*)"" is deleted")]
        public void ThenIsDeleted(string methodologyName)
        {
            bool result =driver.FindElement(By.LinkText(methodologyName)).Displayed;
            if (result == false)

                Assert.Pass(methodologyName + "is deleted");
            else
            
                Assert.Fail(methodologyName + "is not deleted");
         
        }

        [After]
        public void TearDown()
        {

            driver.Quit();
        }

    }
}
