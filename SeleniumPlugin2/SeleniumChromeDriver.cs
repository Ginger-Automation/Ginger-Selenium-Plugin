#region License
/*
Copyright © 2014-2018 European Support Limited

Licensed under the Apache License, Version 2.0 (the "License")
you may not use this file except in compliance with the License.
You may obtain a copy of the License at 

http://www.apache.org/licenses/LICENSE-2.0 

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS, 
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
See the License for the specific language governing permissions and 
limitations under the License. 
*/
#endregion

using Amdocs.Ginger.Plugin.Core;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Amdocs.Ginger.SeleniumPlugin
{
    [GingerService("SeleniumChromeDriver", "Selenium Chrome Driver")]
    public class SeleniumChromeDriver : SeleniumDriverBase
    {
        // public override string Name { get { return "Selenium Chrome Driver"; } }

        public override void LaunchDriver()
        {
            if (System.IO.File.Exists(Path.Combine(mWebDriversFolder, "chromedriver.exe")))
            {
                Console.WriteLine("Using chromedriver.exe at: " + mWebDriversFolder);
                mDriver = new ChromeDriver(mWebDriversFolder);
            }
            else
            {
                Console.WriteLine("WebDriver not found at: " + mWebDriversFolder);
                throw new Exception("WebDriver not found at: " + mWebDriversFolder);
            }
        }

        public void LaunchLinux()
        {
            //String driverPath = "/opt/selenium/";
            // String driverExecutableFileName = "chromedriver";
            String driverPath = "/opt/google/chrome/";
            String driverExecutableFileName = "chrome";
            ChromeOptions options = new ChromeOptions();
            // options.AddArguments("headless");
            options.AddArguments("no-sandbox");
            options.BinaryLocation = "/opt/google/chrome/chrome";
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(driverPath, driverExecutableFileName);
            mDriver = new ChromeDriver(service, options, TimeSpan.FromSeconds(30));
            mDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            mDriver.Manage().Window.Maximize();

            mDriver.Navigate().GoToUrl("http://www.facebook.com");
        }
    }
}
