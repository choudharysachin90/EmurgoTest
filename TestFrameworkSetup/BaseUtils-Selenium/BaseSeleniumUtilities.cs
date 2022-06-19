using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using System.Threading;

namespace TestFrameworkSetup
{
    /// <summary>
    /// BaseSeleniumUtilities - Class which handle your selenium base layer
    /// </summary>
    public class BaseSeleniumUtilities
    {
        /// <summary>
        /// ClickElementBy(Enum to improve readability for accessing element) - By.Id, By.Xpath etc
        /// </summary>
        public enum ClickElementBy
        {
            Id,
            XPath,
            LinkText,
            Name,
            CssSelector
        }

        /// <summary>
        /// NavigateType - navigate your browser website to Backword or forward
        /// </summary>
        public enum NavigateType
        {
            Back,
            Forward
        }

        /// <summary>
        /// OpenURL - Function which will open any url in current browser window
        /// </summary>
        /// <param name="driver">driver object - Firefox, Chrome , edge driver object etc</param>
        /// <param name="url">Url to open</param>
        /// <returns></returns>
        public bool OpenURL(IWebDriver driver, string url)
        {
            driver.Url = url;
            return true;
        }

        /// <summary>
        /// Navigate - Function to go previous or next in browser
        /// </summary>
        /// <param name="driver">driver object - firefox , chrome driver etc</param>
        /// <param name="navigateType">Back or Forward</param>
        /// <param name="url">Only if You want to open a new url</param>
        /// <returns></returns>
        public bool Navigate(IWebDriver driver, NavigateType navigateType ,string url=null)
        {
            if (!string.IsNullOrEmpty(url))
            {
                driver.Navigate().GoToUrl(url);
                return true;
            }

            switch (navigateType)
            {
                case NavigateType.Back:
                    driver.Navigate().Back();
                    break;
                case NavigateType.Forward:
                    driver.Navigate().Forward();
                    break;
                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// ClickElement - Function to click element with different logic - using Id, Xpath etc
        /// </summary>
        /// <param name="driver">driver object - Chrome, Firefox etc</param>
        /// <param name="clickElementBy">How you want to search element using Id, Xpath etc before click</param>
        /// <param name="identifier">Element identifier -> ID, Xpath etc</param>
        /// <returns></returns>
        public bool ClickElement(IWebDriver driver, ClickElementBy clickElementBy, string identifier)
        {
            switch (clickElementBy)
            {
                case ClickElementBy.Id:
                    driver.FindElement(By.Id(identifier)).Click();
                    break;
                case ClickElementBy.XPath:
                    driver.FindElement(By.XPath(identifier)).Click();
                    break;
                case ClickElementBy.LinkText:
                    driver.FindElement(By.LinkText(identifier)).Click();
                    break;
                case ClickElementBy.Name:
                    driver.FindElement(By.Name(identifier)).Click();
                    break;
                case ClickElementBy.CssSelector:
                    driver.FindElement(By.CssSelector(identifier)).Click();
                    break;
                default:
                    break;
            }
            
            return true;
        }

        /// <summary>
        /// ClickElement - Function to click element which is not properly visible and
        /// need to scroll into view
        /// </summary>
        /// <param name="driver">driver object</param>
        /// <param name="XPath">You element's xpath</param>
        /// <returns></returns>
        public bool ClickElement(IWebDriver driver, string XPath)
        {
            var element = driver.FindElement(By.XPath(XPath));
            bool isVisible = element.Displayed;

            if (isVisible)
            {
                ((IJavaScriptExecutor)driver)
             .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            driver.FindElement(By.XPath(XPath)).Click();
            return true;
        }

        /// <summary>
        /// GetText - Function to get text of an element
        /// </summary>
        /// <param name="driver">Driver object- Chrome , Firefox etc</param>
        /// <param name="XPath">Xpath of element</param>
        /// <returns></returns>
        public string GetText(IWebDriver driver, string XPath)
        {
            var itemText = driver.FindElement(By.XPath(XPath)).Text;
            return itemText;
        }

        /// <summary>
        /// SetText - Function to set text in any given input field
        /// </summary>
        /// <param name="driver">Driver object</param>
        /// <param name="XPath">Xpath of element</param>
        /// <param name="textToSet">Text to set</param>
        /// <returns></returns>
        public bool SetText(IWebDriver driver, string XPath, string textToSet)
        {
            driver.FindElement(By.XPath(XPath)).SendKeys(textToSet);
            return true;
        }

        /// <summary>
        /// UploadFile - Function to upload a file using sendkey option
        /// </summary>
        /// <param name="driver">driver object - Chrome , Firefox etc</param>
        /// <param name="XPath">Xpath of element</param>
        /// <param name="filePath">Filepath</param>
        /// <returns></returns>
        public bool UploadFile(IWebDriver driver, string XPath, string filePath)
        {
            //Thread.Sleep(9000);
            driver.FindElement(By.XPath(XPath)).SendKeys(filePath);
            Thread.Sleep(9000);
            return true;
        }

        /// <summary>
        /// IsElementVisibleOnPage Return true or false if element id visible on page or not
        /// </summary>
        /// <param name="driver">driver object - Chrome , Firefox etc</param>
        /// <param name="XPath">Xpath of element</param>
        /// <returns></returns>
        public bool IsElementVisibleOnPage(IWebDriver driver, string XPath)
        {
            return driver.FindElement(By.XPath(XPath)).Displayed;
        }

        public bool IsElementSelected(IWebDriver driver, string XPath)
        {
            return driver.FindElement(By.XPath(XPath)).Selected;
        }

        /// <summary>
        /// IsElementEnabled - Function return true or false if element is enabled
        /// </summary>
        /// <param name="driver">driver object - Chrome , Firefox etc</param>
        /// <param name="XPath">Xpath of Element</param>
        /// <returns></returns>
        public bool IsElementEnabled(IWebDriver driver, string XPath)
        {
            return driver.FindElement(By.XPath(XPath)).Enabled;
        }

        /// <summary>
        /// GetAttributeValue - Get the value of any attribute of any element
        /// </summary>
        /// <param name="driver">driver object - Chrome , Firefox etc</param>
        /// <param name="XPath">Xpath of element</param>
        /// <param name="attributeName">Attribute name - Class, id , alt , src etc</param>
        /// <returns></returns>
        public string GetAttributeValue(IWebDriver driver, string XPath, string attributeName)
        {
            return driver.FindElement(By.XPath(XPath)).GetAttribute(attributeName);
        }

        /// <summary>
        /// ClickElementWithJavScriptExecutor - Click element using javascript executer
        /// </summary>
        /// <param name="driver">driver object - Chrome , Firefox etc</param>
        /// <param name="XPath">xpath of element</param>
        /// <returns></returns>
        public bool ClickElementWithJavScriptExecutor(IWebDriver driver, string XPath)
        {
            IWebElement element = driver.FindElement(By.XPath(XPath));
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            var response = javaScriptExecutor.ExecuteScript("arguments[0].click();", element);
            return true;
        }
    }
}
