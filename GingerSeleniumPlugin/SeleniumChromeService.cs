using Amdocs.Ginger.Plugin.Core;
using Amdocs.Ginger.Plugin.Core.ActionsLib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GingerSeleniumPlugin
{
    [GingerService("SeleniumChromeDriver", "Selenium Chrome Driver")]
    public class SeleniumChromeService : SeleniumDriverBase
    {
        public override string GetDriverFilePath()
        {

            string basepath = Environment.CurrentDirectory;
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                    return Path.Combine(Environment.CurrentDirectory, "Drivers", "chrome", "linux");

                case PlatformID.Win32Windows:
                case PlatformID.Win32NT:
                    return Path.Combine(Environment.CurrentDirectory, "Drivers", "chrome", "win");


                case PlatformID.MacOSX:
                    return Path.Combine(Environment.CurrentDirectory, "Drivers", "chrome", "mac");


                default:
                    throw new PlatformNotSupportedException("Current System is not supported by the plugin");

            }


        }



        public override void StartDriver()
        {
            // String driverPath = "/opt/google/chrome/";
            //String driverExecutableFileName = "chrome";
            ChromeOptions options = new ChromeOptions();

          

            ChromeDriverService service = ChromeDriverService.CreateDefaultService(GetDriverFilePath());
            IWebDriver mDriver = new ChromeDriver(service, options, TimeSpan.FromSeconds(30));
            mDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            mDriver.Manage().Window.Maximize();

            mDriver.Navigate().GoToUrl("http://www.facebook.com");

            base.webDriver = mDriver;
        }




    }
}
