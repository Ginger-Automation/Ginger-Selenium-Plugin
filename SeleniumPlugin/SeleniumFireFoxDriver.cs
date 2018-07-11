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

using System;
using System.IO;
using OpenQA.Selenium.Firefox;

namespace Amdocs.Ginger.SeleniumPlugin
{
    public class SeleniumFireFoxDriver : SeleniumDriver
    {
        public override string Name { get { return "Selenium FireFox Driver"; } }

        public override void LaunchDriver()
        {
            if (System.IO.File.Exists(Path.Combine(mWebDriversFolder, "geckodriver.exe")))
            {
                Console.WriteLine("Using FireFox Gecko driver at: " + mWebDriversFolder);
                mDriver = new FirefoxDriver(mWebDriversFolder);                
            }
            else
            {
                Console.WriteLine("geckodriver.exe not found at: " + mWebDriversFolder);
                throw new Exception("geckodriver.exe not found at: " + mWebDriversFolder);
            }
        }
    }
}
