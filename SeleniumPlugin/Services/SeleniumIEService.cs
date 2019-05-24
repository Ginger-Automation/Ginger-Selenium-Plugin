using Amdocs.Ginger.Plugin.Core;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Services
{
    [GingerService("SeleniumIEService", "Selenium IE Service")]
    public class SeleniumIEService : SeleniumServiceBase
    {
        internal override void StartDriver()
        {
            Driver = new InternetExplorerDriver();
        }
    }
}
