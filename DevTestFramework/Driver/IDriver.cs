using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTestFramework.Driver
{
    // interface which is wrapper over IWebdriver and IScreenShot and provides finctionality related to page and elements 

    public interface IDriver:IWebDriver, ITakesScreenshot
    {
        int ElementTimeout { get; set; }
        new string CurrentWindowHandle { get; }

        void GetPage(string url);

        void GetScreenshot(string filename);

        void SaveScreenShot(IWebDriver driver, string filename, IWebElement element);

        IWebElement FindAndWaitElement(By by);

        
    }
}
