using Amdocs.Ginger.Plugin.Core;
using Ginger.Plugin.Platform.Web;
using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Browser;
using Ginger.Plugins.Web.SeleniumPlugin.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Services
{    
    public abstract class SeleniumServiceBase : IServiceSession, IWebPlatform 
    {
        //TODO: try to make private, pass it if needed
        public IWebDriver Driver;

        // TODO: mark annotation if impl
        public IBrowserActions BrowserActions { get { return new BrowserActions(Driver); } }  //tODO: cache

        // TODO: mark annotation if impl
        public ILocateWebElement LocatLWebElement { get { return new LocateWebElements(Driver); } }  //tODO: cache

        // TODO: mark not impl
        public IAlerts Alerts => throw new NotImplementedException();

        public virtual void StartSession()
        {
            // Must impl in subclass
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



       
    }
}
