using Ginger.Plugin.Platform.Web;
using Ginger.Plugin.Platform.Web.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Browser
{
    public class BrowserActions : IBrowserActions
    {
        IWebDriver mDriver;
        public BrowserActions(IWebDriver driver)
        {
            mDriver = driver;
        }

        public void CloseWindow()
        {
            mDriver.Close();
        }

        public void ExecuteScript()
        {
            throw new NotImplementedException();
        }

        public void FullScreen()
        {
            mDriver.Manage().Window.FullScreen();
        }

        public string GetCurrentUrl()
        {
            return mDriver.Url;
        }

        public string GetTitle()
        {
            return mDriver.Title;
        }

        public string GetWindowHandle()
        {
            return mDriver.CurrentWindowHandle;
        }

        public IReadOnlyCollection<string> GetWindowHandles()
        {
            return mDriver.WindowHandles;
        }

        public void Maximize()
        {
            mDriver.Manage().Window.Maximize();
        }

        public void Minimize()
        {
            mDriver.Manage().Window.Minimize();

        }

        public void NavigateBack()
        {
            mDriver.Navigate().Back();
        }

        public void NavigateForward()
        {
            mDriver.Navigate().Forward();
        }

        public void Refresh()
        {
            mDriver.Navigate().Refresh();
        }


        public void SwitchToFrame(IGingerWebElement WebElement)
        {
            mDriver.SwitchTo().Frame(WebElement as IWebElement);
        }

        public void SwitchToParentFrame()
        {
            mDriver.SwitchTo().ParentFrame();
        }
    }
}
