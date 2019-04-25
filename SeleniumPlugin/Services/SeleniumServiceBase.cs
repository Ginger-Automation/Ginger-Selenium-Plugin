using Amdocs.Ginger.Plugin.Core;
using Ginger.Plugin.Platform.Web;
using Ginger.Plugin.Platform.Web.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Services
{
    public class SeleniumServiceBase : IServiceSession,IBrowserActions
    {
       public IWebDriver Driver;

        public virtual void StartSession()
        {
            throw new NotImplementedException();
        }

        public virtual void StopSession()
        {
            Driver.Quit();
        }

        public static string GetDriverPath(string Driver)
        {
            string platform;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))                            
            {
                platform = "Windows";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                platform = "Mac";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                platform = "Linux";
            }
            else
            {
                throw new PlatformNotSupportedException("Current OS is nor supported by Ginger Selenium Plugin");
            }

           return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Drivers", Driver, platform);
        }



        public void CloseWindow()
        {
            Driver.Close();
        }

        public void ExecuteScript()
        {
            throw new NotImplementedException();
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


        public void SwitchToFrame(IGingerWebElement WebElement )
        {
            Driver.SwitchTo().Frame(WebElement as IWebElement);
        }

        public void SwitchToParentFrame()
        {
            Driver.SwitchTo().ParentFrame();
        }
    }
}
