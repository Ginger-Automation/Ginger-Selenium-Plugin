using Ginger.Plugin.Platform.Web;
using Ginger.Plugin.Platform.Web.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Browser
{
    public class BrowserActions : IBrowserActions
    {
        IWebDriver Driver;
        public BrowserActions(IWebDriver mDriver)
        {
           this.Driver = mDriver;
        }

        public void AcceptAlert()
        {
            Driver.SwitchTo().Alert().Accept();
        }
        public string GetAlertText()
        {
            return Driver.SwitchTo().Alert().Text;
        }
        public void CloseCurrentTab()
        {
            Driver.Close();
        }

        public void CloseWindow()
        {
            foreach (string handle in Driver.WindowHandles)
            {
                Driver.SwitchTo().Window(handle);
                Driver.Close();
            }
        }

        public void DeleteAllCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }

        public void DismissAlert()
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

            if (OpenIn == "NewTab")
            {

                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Driver;
                javaScriptExecutor.ExecuteScript("window.open();");
                Driver.SwitchTo().Window(Driver.WindowHandles[Driver.WindowHandles.Count - 1]);
            }
            else if(OpenIn== "NewWindow")
            {
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Driver;
                javaScriptExecutor.ExecuteScript("newwindow=window.open('about:blank','newWindow','height=250,width=350');if (window.focus) { newwindow.focus()}return false; ");
                Driver.SwitchTo().Window(Driver.WindowHandles[Driver.WindowHandles.Count - 1]);
                Driver.Manage().Window.Maximize();
            }

           

            if (url.ToLower().StartsWith("www"))
            {
                url = "http://" + url;
            }

            Uri uri = ValidateURL(url);
            if (uri != null)
            {
                Driver.Navigate().GoToUrl(uri.AbsoluteUri);
            }
            else
            {
                throw new InvalidDataException(url + " is not a valid URL");
            }


            Driver.Url = url;

             Uri ValidateURL(String sURL)
            {
                Uri myurl;
                if (Uri.TryCreate(sURL, UriKind.Absolute, out myurl))
                {
                    return myurl;
                }
                return null;
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

        public void SendAlertText(string value)
        {
            Driver.SwitchTo().Alert().SendKeys(value);
        }

        public void SwitchToFrame(IGingerWebElement WebElement)
        {
            Driver.SwitchTo().Frame(WebElement.Element as IWebElement);
        }

        public void SwitchToParentFrame()
        {
            Driver.SwitchTo().ParentFrame();
        }

        public string GetPageSource()
        {
            return Driver.PageSource;
        }
    }
}
