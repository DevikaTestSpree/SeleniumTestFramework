using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTestFramework.Driver
{
    public class DriverImpl
    {

               
        private static IWebDriver _myDriver;

        
        private static ITakesScreenshot _screenShot;

        
        public DriverImpl(IWebDriver webDriver, int elementTimeout)
        {
            
            _myDriver = webDriver;
            ElementTimeout = elementTimeout;
        }

        #region Public Properties

        /// <summary>
        /// Gets the current window handle.
        /// </summary>
        public string CurrentWindowHandle
        {
            get
            {
                return _myDriver.CurrentWindowHandle;
            }
        }

        /// <summary>
        /// Gets or sets the element timeout.
        /// </summary>
        public int ElementTimeout { get; set; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title
        {
            get
            {
                return _myDriver.Title;
            }
        }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url
        {
            get
            {
                return _myDriver.Url;
            }

            set
            {
                value = _myDriver.Url;
            }
        }

        

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Use browser's Back Navigation button.
        /// </summary>
        public void Back()
        {
            _myDriver.Navigate().Back();
        }

        /// <summary>
        /// The close.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Close()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The find and wait element.
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        /// <returns>
        /// The <see cref="IWebElement"/>.
        /// </returns>
        /// <exception cref="TimeoutException">
        /// </exception>
        public IWebElement FindAndWaitElement(By by)
        {
            try
            {
                if (ElementTimeout > 0)
                {
                    var wait = new WebDriverWait(_myDriver, TimeSpan.FromSeconds(ElementTimeout));
                    return wait.Until(drv => _myDriver.FindElement(by));
                }

                return _myDriver.FindElement(by);
            }
            catch (Exception toe)
            {
                throw new TimeoutException(toe.Message);
            }
        }

        
        public void GetPage(string url)
        {
            _myDriver.Manage().Window.Maximize();
            _myDriver.Navigate().GoToUrl(url);
        }

        
        public Screenshot GetScreenshot()
        {
            _screenShot = _myDriver as ITakesScreenshot;
            return _screenShot.GetScreenshot();
        }

        
        public void GetScreenshot(string filename)
        {
        }

        /// <summary>
        /// The manage.
        /// </summary>
        /// <returns>
        /// The <see cref="IOptions"/>.
        /// </returns>
        public IOptions Manage()
        {
            return _myDriver.Manage();
        }

        /// <summary>
        /// Mouse over element
        /// </summary>
        /// <param name="driver">
        /// </param>
        /// <param name="by">
        /// </param>
        public void MouseOverElement(IDriver driver, By by)
        {
            //var wait = new WebDriverWait(_myDriver, TimeSpan.FromSeconds(ElementTimeout));

            //IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));

            //var action = new Actions(_myDriver);

            //action.MoveToElement(element).Perform();
        }

        
        public INavigation Navigate()
        {
            return _myDriver.Navigate();
        }

        public void Quit()
        {
            _myDriver.Quit();
        }

        /// <summary>
        ///     Referesh the page , its like F5
        /// </summary>
        public void RefershPage()
        {
            _myDriver.Navigate().Refresh();
        }

       
        public void SaveScreenShot(IWebDriver driver, string filename, IWebElement element)
        {
            
        }

       
        
        public void ReportTestException(string testName, Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            
        }

        private static string GetScreenshotFilename(string testName)
        {
            return string.Format("{0}_{1}.jpg", DateTime.UtcNow.ToString("yyyy-MM-dd"), testName);
        }

        
        #endregion

        

    }
}

