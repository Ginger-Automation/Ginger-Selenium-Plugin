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
        IWebDriver Driver;
        public BrowserActions(IWebDriver Driver)
        {
            Driver = Driver;
        }

        public void AcceptMessageBox()
        {
            Driver.SwitchTo().Alert().Accept();
        }

        public void CloseCurrentTab()
        {
            Driver.Close();
        }

        public void CloseWindow()
        {
            Driver.Close();
        }

        public void DeleteAllCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        public void DismissMessageBox()
        {
            Driver.SwitchTo().Alert().Dismiss();
        }

        public object ExecuteScript(string script)
        {
          return  ((IJavaScriptExecutor)Driver).ExecuteScript(script);
        }

        public void FullScreen()
        {
            Driver.Manage().Window.FullScreen();
        }

        public string GetCurrentUrl()
        {
            return Driver.Url;
        }

        public string GetTitle()
        {
            return Driver.Title;
        }

        public string GetWindowHandle()
        {
            return Driver.CurrentWindowHandle;
        }

        public IReadOnlyCollection<string> GetWindowHandles()
        {
            return Driver.WindowHandles;
        }

        public void Maximize()
        {
            Driver.Manage().Window.Maximize();
        }

        public void Minimize()
        {
            Driver.Manage().Window.Minimize();

        }

        public void Navigate(string url,string OpenIn)
        {
            if (OpenIn == "Current")
            {

                Driver.Url = url;
            }



        }

        public void NavigateBack()
        {
            Driver.Navigate().Back();
        }

        public void NavigateForward()
        {
            Driver.Navigate().Forward();
        }

        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }

        public void SetAlertBoxText(string value)
        {
            Driver.SwitchTo().Alert().SendKeys(value);
        }

        public void SwitchToFrame(IGingerWebElement WebElement)
        {
            Driver.SwitchTo().Frame(WebElement as IWebElement);
        }

        public void SwitchToParentFrame()
        {
            Driver.SwitchTo().ParentFrame();
        }
    }
}
