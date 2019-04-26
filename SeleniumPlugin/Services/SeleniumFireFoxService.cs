using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Firefox;

namespace Ginger.Plugins.Web.SeleniumPlugin.Services
{
    [GingerService("SeleniumFireFoxService", "Selenium Fire Fox Service")]
    public class SeleniumFireFoxService : SeleniumServiceBase
    {
        public override void StartSession()
        {
            Driver = new FirefoxDriver();    
        }

    }
}
