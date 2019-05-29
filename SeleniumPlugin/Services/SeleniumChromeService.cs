using Amdocs.Ginger.Plugin.Core;
using Amdocs.Ginger.Plugin.Core.Attributes;
using Ginger.Plugin.Platform.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Services
{

    [GingerService("SeleniumChromeService", "Selenium Chrome Service")]
    public class SeleniumChromeService : SeleniumServiceBase
    {
        [Default(false)]
        [ValidValue(new bool[] { true,false})]
        [ServiceConfiguration("Headless Browser", "Run Browser in UI ")]
        public bool HeadlessBrowserMode { get; set; }


        [ServiceConfiguration("User Profile Path", "Full path for the User Profile folder")]
        public string UserProfileFolderPath { get; set; }


        [ServiceConfiguration("ExtensionPath", "Path to extension to be enabled")]
        public string ExtensionPath { get; set; }

        [ServiceConfiguration("Download Folder path","Only for Chrome | Define Download Folder path")]
        public string DownloadFolderPath { get; set; }

        internal override void StartDriver(Proxy mProxy)
        {
            ChromeOptions Options = new ChromeOptions();
           Options.Proxy = mProxy;

            if (!(string.IsNullOrEmpty(ExtensionPath) || string.IsNullOrWhiteSpace(ExtensionPath)))
            {
                Options.AddExtension(Path.GetFullPath(ExtensionPath));
            }
            if (HeadlessBrowserMode)
            {
                Options.AddArgument("--headless");
            }

            if ((!(string.IsNullOrEmpty(UserProfileFolderPath) || string.IsNullOrWhiteSpace(UserProfileFolderPath) )&& System.IO.Directory.Exists(UserProfileFolderPath)))

            {
                Options.AddArguments("user-data-dir=" + UserProfileFolderPath);
            }

            if (!(string.IsNullOrEmpty(DownloadFolderPath) || string.IsNullOrWhiteSpace(DownloadFolderPath)))
            {
                if (!System.IO.Directory.Exists(DownloadFolderPath))
                {
                    System.IO.Directory.CreateDirectory(DownloadFolderPath);
                }
                Options.AddUserProfilePreference("download.default_directory", DownloadFolderPath);
            }
            if (BrowserPrivateMode)
            {
                Options.AddArgument("--incognito");
            }

            Driver = new ChromeDriver(SeleniumServiceBase.GetDriverPath("Chrome"),Options);            
        }

    }
}
