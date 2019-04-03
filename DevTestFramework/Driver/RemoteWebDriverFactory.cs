using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTestFramework.Driver
{
    public class RemoteWebDriverFactory
    {
        public static IWebDriver GetDriver(IDriverConfiguration configuration)
        {
            Uri seleniumServer = new Uri(configuration.SeleniumServerAddress);
            Browser browser = Browser.Chrome; //= configuration.Browser.AsEnum<Browser>();
            IWebDriver driver = RemoteWebDriverFactory.GetCapabilityFor(browser, seleniumServer);
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();

                        

            return driver;
        }

        public static IWebDriver GetCapabilityFor(Browser browser, Uri seleniumServer)
        {
            IWebDriver driver;
            switch (browser)
            {
                case Browser.Chrome:
                    driver = new RemoteWebDriver(seleniumServer, new ChromeOptions());
                    break;
                case Browser.InternetExplorer:
                    driver = new RemoteWebDriver(seleniumServer, new InternetExplorerOptions());
                    break;
                default:
                    driver = new RemoteWebDriver(seleniumServer, new FirefoxOptions());
                    break;
            }

            return driver;
        }

    }
}
