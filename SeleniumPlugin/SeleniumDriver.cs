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

using Amdocs.Ginger.Plugin;
using GingerPlugInsNET.ActionsLib;
using GingerPlugInsNET.DriversLib;
using GingerPlugInsNET.PlugInsLib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using HtmlAgilityPack;
using System.Drawing;
using GingerCoreNET.ReporterLib;

namespace Amdocs.Ginger.SeleniumPlugin          
{
    public abstract class SeleniumDriver : PluginDriverBase, ITakeScreenShot, IUIElementAction, IWebBrowser, IRecord
    {
        internal IWebDriver mDriver = null;

        //TODO: add driver config - capabilities
        // Get assmebly location then goto web drivers
        internal string mWebDriversFolder;

        public override void StartDriver()
        {
            if (mDriver != null)
            {
                Console.WriteLine("Driver is already running!, please close first before start a new one");
                return;
            }

            /// Simplified !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Assembly a = Assembly.GetExecutingAssembly();
            string aa = a.ManifestModule.Name;
            mWebDriversFolder = Path.Combine(a.Location,"WebDrivers");
            string s = mWebDriversFolder.Replace(aa, "");
            mWebDriversFolder = s;

            Console.WriteLine("Starting Selenium Driver - " + this.Name);
            this.LaunchDriver();
        }

        public abstract void LaunchDriver();

        public override void CloseDriver()
        {
            if (mDriver != null)
            {
                mDriver.Close();
                mDriver.Dispose();
            }
        }

        public override void BeforeRunAction(GingerAction GA)
        {
            Console.WriteLine("Before Action Run: " + GA.ID);
        }

        public override void AfterRunAction(GingerAction GA)
        {
            Console.WriteLine("After Action Run: " + GA.ID);
        }

        // The selenium driver actions unique actions
        [GingerAction("ExecuteScript", "Execute Java script")]        
        public void ExecuteScript(GingerAction GA, string script, object[] args)
        {
            ((IJavaScriptExecutor)mDriver).ExecuteScript(script, args);            
        }

        [GingerAction("SpeedTest", "SpedTest Test")]
        public void SpeedTest(GingerAction gingerAction, string message, int sleep)
        {
            // Do Work
            gingerAction.Output.Add("key2", "hello 2");
            gingerAction.Output.Add("message", message);
            gingerAction.Output.Add("message len", message.Length.ToString());   /// !!!!!!!!!!!!!!            

            Thread.Sleep(sleep);

            gingerAction.ExInfo = "ex1";
            gingerAction.AddError("aaa", "aaaaa errr");
        }

        #region ITakeScreenShot impl
        public List<eScreens> SupportedScreens()
        {
            return new List<eScreens>() { eScreens.Active, eScreens.All };
        }

        public void TakeScreenShot(GingerAction gingerAction, eScreens screens = eScreens.Active)
        {
            //TODO: handle screen - take all etc..

            Screenshot SS = ((ITakesScreenshot)mDriver).GetScreenshot();
            byte[] b = SS.AsByteArray;
            gingerAction.Output.Add("SC1", b);
        }

        #endregion ITakeScreenShot
        
        public void UIElementAction(GingerAction gingerAction, eElementType elementType, eLocateBy locateBy, string locateValue, eElementAction elementAction, string value = null)
        {
            Console.WriteLine("HandleUIElementAction");
            //First find the element
            IWebElement e = LocateElement(gingerAction, elementType, locateBy, locateValue);
                        
            if (e == null)
            {
                Console.WriteLine("Element not found - " + elementType + " - " + locateBy + " " + locateValue);
                gingerAction.AddError("HandleUIElementAction", "Cannot find element: " + elementType + locateBy + " " + locateValue);
                return;                
            }

            PerformUIElementAction(gingerAction, e, elementAction, value);                        
        }

        private void PerformUIElementAction(GingerAction gingerAction, IWebElement e, eElementAction elementAction, string value)
        {
            switch (elementAction)
            {
                case eElementAction.Click:
                    e.Click();                    
                    break;
                case eElementAction.SetValue:

                    //TODO: override in sub driver if needed
                    e.Clear();
                    e.SendKeys(value);
                    break;
                case eElementAction.GetValue:
                    gingerAction.Output.Add("Text", e.Text);
                    break;
                default:
                    gingerAction.AddError("PerformUIElementAction", "Unknown element action - " + elementAction);
                    break;
            }
        }

        private IWebElement LocateElement(GingerAction gingerAction, eElementType elementType, eLocateBy locateBy, string locateValue)
        {
            try
            {
                IWebElement e = null;
                switch (locateBy)
                {
                    case eLocateBy.Id:
                        e = mDriver.FindElement(By.Id(locateValue));
                        return e;
                    case eLocateBy.Name:
                        e = mDriver.FindElement(By.Name(locateValue));
                        return e;
                    case eLocateBy.Text:
                        e = mDriver.FindElement(By.CssSelector("text=" + locateValue));                        
                        return e;
                    case eLocateBy.XPath:
                        e = mDriver.FindElement(By.XPath(locateValue));
                        return e;
                    //TODO: all the rest
                    default:
                        gingerAction.AddError("LocateElement", "Locator not implemented - " + locateBy);
                        return null;
                }
            }
            catch (Exception ex)
            {
                gingerAction.AddError("LocateElement", ex.Message);
                return null;
            }
        }

        public void Navigate(GingerAction gingerAction, string URL)
        {        
            Console.WriteLine("GotoURL - " + URL);
            mDriver.Navigate().GoToUrl(URL);
            gingerAction.ExInfo += "Navigated to: " + URL;        
    }

        public void Submit(GingerAction gingerAction)
        {
        }

        public void StartRecording()
        {
            InjectRecordingIfNotInjected();
        }

        public void StopRecording()
        {
            throw new NotImplementedException();
        }

        void AddJavaScriptToPage(string script)
        {
            try
            {              
                string script3 = GetInjectJSSCript(script);
                var v = ((IJavaScriptExecutor)mDriver).ExecuteScript(script3, null);
            }
            catch (Exception ex)
            {
                Reporter.ToLog(eLogLevel.ERROR, $"Method - {MethodBase.GetCurrentMethod().Name}, Error - {ex.Message}");
            }

        }

        String GetInjectJSSCript(string script)
        {            
            string ScriptMin = MinifyJS(script);
            // Get the Inject code
            string script2 = GetJS("injectjavascript.js");
            script2 = MinifyJS(script2);
            //Note minifier change ' to ", so we change it back, so the script can have ", but we wrap it all with '
            string script3 = script2.Replace("\"%SCRIPT%\"", "'" + ScriptMin + "'");

            return script3;
        }

        private string MinifyJS(string script)
        {
            //TODO: cache if possible
            var minifier = new Microsoft.Ajax.Utilities.Minifier();
            var minifiedString = minifier.MinifyJavaScript(script);
            if (minifier.Errors.Count > 0)
            {
                //There are ERRORS !!!
                Console.WriteLine(script);
                return null;
            }
            return minifiedString + ";";
        }

        public void InjectRecordingIfNotInjected()
        {
            string isRecordExist = "no";
            try
            {
                isRecordExist = (string)((IJavaScriptExecutor)mDriver).ExecuteScript("return GingerRecorderLib.IsRecordExist();", null);
            }
            catch
            {
            }

            if (isRecordExist == "no")
            {
                InjectGingerHTMLHelper();
                InjectScript("GingerHTMLRecorder.js");
            }
        }

        public void InjectGingerHTMLHelper()
        {
            //do once
            AddJavaScriptToPage(GetJS("PayLoad.js"));
            AddJavaScriptToPage(GetJS("gingerhtmlhelper.js"));
            
            ((IJavaScriptExecutor)mDriver).ExecuteScript("define_GingerLib();", null);

            //Inject JQuery
            InjectScript("jquery.min.js");

            // Inject XPath
            InjectScript("GingerLibXPath.js");

            // Inject code which can find element by XPath            
            InjectScript("wgxpath.install.js");            
        }

        object InjectScript(string FileName)
        {
            string js = GetJS(FileName);                        
            object rc = ((IJavaScriptExecutor)mDriver).ExecuteScript("return GingerLib.AddScript(arguments[0]);", js);
            return rc;
        }

        string GetJS(string fileName)
        {            
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(typeof(SeleniumDriver), "JavaScripts." + fileName))
            {
                StreamReader sr = new StreamReader(stream);
                string js = sr.ReadToEnd();
                return js;
            }            
        }

        public List<UIElement> GetVisibleElements()
        {
            string s = mDriver.PageSource;

            HtmlDocument doc = new HtmlDocument();            
            doc.LoadHtml(s);
            
            List<UIElement> list = new List<UIElement>();
            foreach (HtmlNode n in doc.DocumentNode.Descendants("input"))    
            {                                
                IWebElement e = mDriver.FindElement(By.XPath(n.XPath));
                
                Point location = e.Location;
                Size size = e.Size;

                UIElement uIElement = new UIElement();
                uIElement.ElementType = n.NodeType.ToString();
                uIElement.X = location.X;
                uIElement.Y = location.Y;
                uIElement.XPath = n.XPath;

                //TODO: add locators
                // Add data
                
                list.Add(uIElement);
            }
            return list;
        }
    }
}