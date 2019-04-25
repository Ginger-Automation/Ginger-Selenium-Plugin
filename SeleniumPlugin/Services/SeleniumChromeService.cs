using Amdocs.Ginger.Plugin.Core;
using Ginger.Plugin.Platform.Web;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Services
{
    public class SeleniumChromeService : SeleniumServiceBase
    {
        public override void StartSession()
        {

            ChromeOptions Options = new ChromeOptions();


            Driver = new ChromeDriver(SeleniumServiceBase.GetDriverPath("Chrome"),Options);
            Driver.Url = "http://ginger.amdocs.com";
        }

    }
}
