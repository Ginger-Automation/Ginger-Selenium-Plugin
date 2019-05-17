﻿using Amdocs.Ginger.Plugin.Core;
using Amdocs.Ginger.Plugin.Core.ActionsLib;
using Ginger.Plugin.Platform.Web;
using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugin.Platform.Web.Execution;
using Ginger.Plugins.Web.SeleniumPlugin.Browser;
using Ginger.Plugins.Web.SeleniumPlugin.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Services
{
    public abstract class SeleniumServiceBase : IServiceSession, IWebPlatform, IScreenShotSetvice
    {


        #region Plugin Configuration
        [GingerServiceConfiguration("Proxy Type", "Proxy type", typeof(string), "ProxyAutoConfigure", new object[] { "Direct", "Manual", "ProxyAutoConfigure", "AutoDetect", "System" })]
        public string Proxy { get; set; }


        [GingerServiceConfiguration("Proxy Auto Config Url", "Proxy Auto Config Url", typeof(string), "url")]
        public string ProxyAutoConfigUrl { get; set; }

        [GingerServiceConfiguration("ImplicitWait", "Amount of time the driver should wait when searching for an element if it is not immediately present", typeof(int), 30)]
        public int ImplicitWait { get; set; }
        #endregion











        #region Common Properties
        //TODO: try to make private, pass it if needed
        public IWebDriver Driver;

        private IBrowserActions mBrowserActions { get; set; }
        // TODO: mark annotation if impl
        public IBrowserActions BrowserActions { get { return mBrowserActions; } }
        private ILocateWebElement mLocatLWebElement { get; set; }
        // TODO: mark annotation if impl
        public ILocateWebElement LocateWebElement { get { return mLocatLWebElement; } }  //tODO: cache

        // TODO: mark not impl
        public IAlerts Alerts =>throw new NotImplementedException();

        public IPlatformActionHandler PlatformActionHandler { get; set; } = new WebPlatformActionHandler();
        #endregion
      
        public abstract void StartDriver();

        public void StartSession()
        {
            this.StartDriver();
            mBrowserActions = new BrowserActions(this.Driver);
            mLocatLWebElement = new LocateWebElements(this.Driver);
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

        public Bitmap GetActiveScreenImage()
        {
            Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
            return Base64StringToBitmap(ss.AsBase64EncodedString);
        }

        public List<Bitmap> GetAllScreensImages()
        {
            List<Bitmap> Screenshots = new List<Bitmap>();
            String currentWindow = Driver.CurrentWindowHandle;

            ReadOnlyCollection<string> openWindows = Driver.WindowHandles;
            foreach (String winHandle in openWindows)
            {
                Driver.SwitchTo().Window(winHandle);
                Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
                
                Screenshots.Add(Base64StringToBitmap(ss.AsBase64EncodedString));
            }
            //Switch back to the last window
            Driver.SwitchTo().Window(currentWindow);
            return Screenshots;
        }

        private static Bitmap Base64StringToBitmap(string base64String)
        {
            Bitmap bmpReturn = null;


            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);


            memoryStream.Position = 0;


            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);


            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;


            return bmpReturn;
        }

   
    }
}
