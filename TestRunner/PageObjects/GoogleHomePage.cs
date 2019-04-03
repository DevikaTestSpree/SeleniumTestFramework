using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTestRunner.PageObjects
{
    public class GoogleHomePage
    {
        private readonly RemoteWebDriver _driver;
        public GoogleHomePage(RemoteWebDriver driver)
        {
            _driver = driver;
                
        }
        IWebElement txtToSearch => _driver.FindElementByName("q");
        IWebElement searchButton => _driver.FindElementByName("btnK");
        IWebElement feelingLucky => _driver.FindElementById("gbqfbb");
        IWebElement resultList => _driver.FindElementByXPath("//*[@id='rso']/div/div");

        //Instead of using xpath ,I can also create the ID for about and store menu and then iterate through each division to get the particular element 
        IWebElement aboutMenu => _driver.FindElementByXPath(@"//*[@id='hptl']/a[1]");
        IWebElement storeMenu => _driver.FindElementByXPath(@"//*[@id='hptl']/a[2]");
        IWebElement gMail => _driver.FindElementByXPath(@"//*[@id='gbw']/div/div/div[1]/div[1]/a");
        IWebElement images => _driver.FindElementByXPath(@"//*[@id='gbw']/div/div/div[1]/div[2]/a");

        public void SearchText(string textToSearch)
        {

            try
            {
                txtToSearch.SendKeys(textToSearch);
                Actions builder = new Actions(_driver);
                builder.SendKeys(Keys.Enter);
                System.Threading.Thread.Sleep(500);
                searchButton.Click();
            }
            catch (ElementNotVisibleException ex )
            {
                //Write to the log file that exception occured
                //take screenshot
            }


        }
        public List<string> GetResultList()
        {
            List<string> searchList = new List<string> { };

            ReadOnlyCollection<IWebElement> displayedOptions = _driver.FindElementsByXPath("//*[@id='rso']/div/div");

            foreach (var item in displayedOptions)
            {
                searchList.Add(item.Text);
            }


            return searchList;
        }


        public void ClickFeelingLucky()
        {
            feelingLucky.Click();
        }


    }

    
}
