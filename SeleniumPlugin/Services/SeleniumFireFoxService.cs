using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Firefox;
using Amdocs.Ginger.Plugin.Core.Attributes;
using OpenQA.Selenium;

namespace Ginger.Plugins.Web.SeleniumPlugin.Services
{
    [GingerService("SeleniumFireFoxService", "Selenium Fire Fox Service")]
    public class SeleniumFireFoxService : SeleniumServiceBase
    {
        [Default(false)]
        [ValidValue(new bool[] { true, false })]
        [ServiceConfiguration("Headless Browser", "Run Browser in UI ")]
        public bool HeadlessBrowserMode { get; set; }

        [ServiceConfiguration("User Profile Path","Full path for the User Profile folder")]
        public string UserProfileFolderPath { get; set; }

        internal override void StartDriver(Proxy mProxy)
        {
       
            FirefoxOptions FirefoxOption = new FirefoxOptions();
            FirefoxOption.Proxy = mProxy;
            FirefoxOption.AcceptInsecureCertificates = true;
            if (HeadlessBrowserMode )
            {
                FirefoxOption.AddArgument("--headless");
            }
            if (!string.IsNullOrEmpty(UserProfileFolderPath) && System.IO.Directory.Exists(UserProfileFolderPath))
            {
                FirefoxProfile ffProfile2 = new FirefoxProfile();
                ffProfile2 = new FirefoxProfile(UserProfileFolderPath);

                FirefoxOption.Profile = ffProfile2;
            }

            Driver = new FirefoxDriver(SeleniumServiceBase.GetDriverPath("FireFox"),FirefoxOption, TimeSpan.FromSeconds(Convert.ToInt32(HttpServerTimeOut)));    
        }

    }
}
