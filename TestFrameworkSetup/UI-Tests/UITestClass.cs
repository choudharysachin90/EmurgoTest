using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TestFrameworkSetup.DataReader;
using static TestFrameworkSetup.DataReader.EmurgoSchema;

namespace TestFrameworkSetup
{
    [TestFixture]
    public class UITests
    {
        private ChromeDriver chromeDriver;
        private string urlYoroiWaalet = "chrome-extension://ffnbelfdoeiohenkjibnmadjiehjhajb/main_window.html#/";
        private BaseSeleniumUtilities utilitiesObject;
        private Logger logger;
        private string chromeDriveLocation = @"D:\C#Selenium\chromedriver_win32";
        string testDataPath = @"D:\C#Selenium\TestData.xml";
        private TestDataReader testDataReader;
        private Emurgo emurgoTestData;
        private int expectedBrowserCount = 5;

        [OneTimeSetUp]
        public void ClassSetup()
        {
            utilitiesObject = new BaseSeleniumUtilities();
            logger = new Logger();
            testDataReader = new TestDataReader();
            emurgoTestData = testDataReader.DeserializeToObject<EmurgoSchema.Emurgo>(testDataPath);
        }

        [SetUp]
        public void Setup()
        {
            var driverLocation = chromeDriveLocation;
            ChromeOptions chromeOptions = new ChromeOptions();
            string pathExtension = @"D:\C#Selenium\ffnbelfdoeiohenkjibnmadjiehjhajb\4.14.500_0.crx";
            chromeOptions.AddExtension(pathExtension);
            

            chromeDriver = new ChromeDriver(driverLocation, chromeOptions);
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            
            //WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        [TearDown]
        public void CleanUp()
        {
            chromeDriver.Quit();
        }

        [Test]
        public void DemoTest1()
        {
            logger.InitializeLogger(TestContext.CurrentContext.Test.Name);
            chromeDriver.Manage().Window.Maximize();
            
            //Open a url
            utilitiesObject.OpenURL(chromeDriver, urlYoroiWaalet);
            logger.LogStepInfo(Logger.MessageType.Info, "Url has been opened successfully");

            //Validate Logo, Language Dropdown , Button , Chat button is displaying
            WebDriverWait webDriverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(50));
            webDriverWait.Until(cond => cond.FindElement(By.XPath(Xpaths.WalletLaunchUI.ContinueButton)).Enabled);

            Assert.IsTrue(utilitiesObject.IsElementVisibleOnPage(chromeDriver, Xpaths.WalletLaunchUI.YoroiLogoXPath));
            Assert.IsTrue(utilitiesObject.IsElementVisibleOnPage(chromeDriver, Xpaths.WalletLaunchUI.ChatButton));
            Assert.IsTrue(utilitiesObject.IsElementVisibleOnPage(chromeDriver, Xpaths.WalletLaunchUI.ContinueButton));
            Assert.IsTrue(utilitiesObject.IsElementVisibleOnPage(chromeDriver, Xpaths.WalletLaunchUI.LanguageSelectDropDown));
            Assert.IsTrue(utilitiesObject.IsElementVisibleOnPage(chromeDriver, Xpaths.WalletLaunchUI.SelectYourLanguageLabel));

            logger.LogStepInfo(Logger.MessageType.Info, "All items are visible -  validated successfully");

            //Validate If English is selected by default
            Assert.AreEqual("English", utilitiesObject.GetText(chromeDriver, Xpaths.WalletLaunchUI.DefaultLanguageSelect));

            //Get all the values of dropdown from page
            utilitiesObject.ClickElement(chromeDriver, Xpaths.WalletLaunchUI.LanguageSelectDropDown);
            List<string> download_Drop_Down = new List<string>();
            for (int indexInDropDown = 1; indexInDropDown < expectedBrowserCount + 1; indexInDropDown++)
            {
                string dynamicXpath = string.Format(Xpaths.WalletLaunchUI.AllAvailableLanguages, indexInDropDown);
                download_Drop_Down.Add(utilitiesObject.GetText(chromeDriver, dynamicXpath));
            }
            logger.LogStepInfo(Logger.MessageType.Info, "All values from Language drop down has been fetched successfully");

            //Validate the languages from expected values
            for (int i = 0; i < download_Drop_Down.Count; i++)
            {
                Assert.AreEqual(emurgoTestData.TestData[0].Parameter[i].Value, download_Drop_Down[i]);
            }
                       
            //validate actual and expected download drop down data
            
            logger.LogStepInfo(Logger.MessageType.Info, "Language Drop down : Actual and Expected Values has been validated successfully");
            logger.DisposeLogger();
        }               
    }
}