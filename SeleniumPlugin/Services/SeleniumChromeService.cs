using Amdocs.Ginger.Plugin.Core;
using Ginger.Plugin.Platform.Web;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Services
{

    [GingerService("SeleniumChromeService", "Selenium Chrome Service")]
    public class SeleniumChromeService : SeleniumServiceBase
    {
        public override void StartDriver()
        {
            ChromeOptions Options = new ChromeOptions();
            Driver = new ChromeDriver(SeleniumServiceBase.GetDriverPath("Chrome"),Options);            
        }

    }
}
