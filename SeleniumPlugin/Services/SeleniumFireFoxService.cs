using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Firefox;
using Amdocs.Ginger.Plugin.Core.Attributes;

namespace Ginger.Plugins.Web.SeleniumPlugin.Services
{
    [GingerService("SeleniumFireFoxService", "Selenium Fire Fox Service")]
    public class SeleniumFireFoxService : SeleniumServiceBase
    {
        [Default(false)]
        [ValidValue(new bool[] { true, false })]
        [ServiceConfiguration("Headless Browser", "Run Browser in UI ")]
        public bool HeadlessBrowserMode { get; set; }


        internal override void StartDriver()
        {
            Driver = new FirefoxDriver();    
        }

    }
}
