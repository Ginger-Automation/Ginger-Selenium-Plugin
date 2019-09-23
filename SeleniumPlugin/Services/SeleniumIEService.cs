using Amdocs.Ginger.Plugin.Core;
using Amdocs.Ginger.Plugin.Core.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Services
{
    [GingerService("SeleniumIEService", "Selenium IE Service")]
    public class SeleniumIEService : SeleniumServiceBase
    {
        [ServiceConfiguration("Enable Native Events ","EnableNativeEvents(true) so as to perform native events smoothly on IE ")]
        public bool EnableNativeEvents { get; set; }

        [ServiceConfiguration("Use 64Bit Browser", "Use 64Bit Browser")]
        public bool Use64Bitbrowser { get; set; }
        internal override void StartDriver(Proxy mProxy)
        {

            InternetExplorerOptions ieoptions = new InternetExplorerOptions();

            ieoptions.EnsureCleanSession = true;
            ieoptions.IgnoreZoomLevel = true;
            ieoptions.Proxy = mProxy;
            ieoptions.EnableNativeEvents = EnableNativeEvents;

            if (BrowserPrivateMode)
            {
                ieoptions.ForceCreateProcessApi = true;
                ieoptions.BrowserCommandLineArguments = "-private";
            }
            Driver = new InternetExplorerDriver(SeleniumServiceBase.GetDriverPath("InternetExplorer"), ieoptions);
        }
    }
}
