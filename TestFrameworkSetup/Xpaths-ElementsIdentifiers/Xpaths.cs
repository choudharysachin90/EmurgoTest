using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkSetup
{
    public static class Xpaths
    {
        public struct WalletLaunchUI
        {
            public static string YoroiLogoXPath = "//*[@id='yoroi-logo-blue_inline_svg__tick']";
            public static string SelectYourLanguageLabel = "//label[@id='languages-select']";
            public static string LanguageSelectDropDown = "//div[@aria-haspopup='listbox']";
            public static string DefaultLanguageSelect = "//div[@aria-haspopup='listbox']/div/span[2]";
            public static string ContinueButton = "//button[text()='Continue']";
            public static string ChatButton = "//*[@id='root']/div/div[2]/button";
            public static string AllAvailableLanguages = "//ul[@aria-labelledby = 'languages-select']/li[{0}]";

        }

        public struct AboutPageXpaths
        {
            public static string ClickTextBox = "//li[@id='item-0']/span";
            public static string FillUserName = "//input[@id='userName']";
        }

        public struct SupportPageXPaths
        {
            public static string ClickCheckBox = "//li[@id='item-1']/span";
            public static string SelectCheckBox = "//span[text()='Home']";
        }
    }
}
