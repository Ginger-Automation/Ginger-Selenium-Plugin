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
using Amdocs.Ginger.SeleniumPlugin;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace SeleniumPluginTest
{
    [Level3]
    [TestClass]
    public class SeleniumDriverTest
    {
        static SeleniumDriver mSeleniumDriver;

        // Since the driver can run one action at a time and UT can run multi threaded we use mutex to run one each time
        Mutex mutex = new Mutex();   

        [ClassInitialize]
        public static void ClassInit(TestContext TC)
        {
            // mSeleniumDriver = new SeleniumFireFoxDriver();            
            mSeleniumDriver = new SeleniumChromeDriver();
            mSeleniumDriver.Start();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            mSeleniumDriver.Stop();
        }


        [TestInitialize]
        public void TestInitialize()
        {
            // Wait until it is safe to enter.
            mutex.WaitOne();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            mutex.ReleaseMutex();    // Release the Mutex.
        }

        
        public void GotoHTMLControls()
        {
            string HTMLControlFile = "file://" + TestResources.GetTestResourcesFile("HTMLControls.html");
            GingerAction GA1 = new GingerAction();            
            mSeleniumDriver.Navigate(GA1, HTMLControlFile);
        }

        [TestMethod]
        public void GoToGoogleURL()
        {
            // Arrange
            string URL = "https://www.google.com";
            GingerAction GA = new GingerAction();
            
            // Act            
            mSeleniumDriver.Navigate(GA, URL);

            // Assert
            Assert.AreEqual(GA.ExInfo, "Navigated to: " + URL);
            Assert.AreEqual(GA.Errors, null);

            //TODO: add check to get title so see we got to google
        }


        //[TestMethod]
        //public void SpeedTest()
        //{
        //    // Arrange
        //    GingerAction GA = new GingerAction();

        //    // Act
        //    Stopwatch st = Stopwatch.StartNew();
        //    for (int i = 0; i < 100; i++)   // Total 1 sec
        //    {
        //        GA.ID = "SpeedTest";
        //        GA.InputParams["message"].Value = "aaaa";    // make value default operator
        //        GA.InputParams["sleep"].Value = 10;  //  do a small sleep
        //        mSeleniumDriver.RunAction(GA);
        //    }
        //    st.Stop();
        //    double ela = st.ElapsedMilliseconds;            

        //    // Assert
        //    Assert.AreEqual(GA.Output["key2"], "hello 2"); 
        //    Assert.IsTrue(ela < 1500, "Elapsed < 1500");  

        //}



        //[TestMethod]
        //public void HTMLControls()
        //{
        //    // Arrange
        //    GotoHTMLControls();
        //    GingerAction GA = new GingerAction("UIElementAction");
            
        //    // Act            
        //    mSeleniumDriver.UIElementAction(GA, eElementType.TextBox, eLocateBy.Id, "GingerPhone", eElementAction.SetValue, "Hello World");
        
        //    // Assert                        
        //    Assert.AreEqual(GA.Errors, null);
        //}

        //[TestMethod]
        //public void HTMLControlsUsingParamsManual()
        //{
        //    // Arrange
        //    GotoHTMLControls();            
        //    GingerAction GA2 = new GingerAction("UIElementAction");

        //    // Act
        //    GA2.InputParams["elementType"].Value = "TextBox";
        //    GA2.InputParams["locateBy"].Value = "Id";
        //    GA2.InputParams["locateValue"].Value = "GingerPhone";
        //    GA2.InputParams["elementAction"].Value = "SetValue";
        //    GA2.InputParams["value"].Value = "Hello World";

        //    mSeleniumDriver.RunAction(GA2);

        //    // Assert                        
        //    Assert.AreEqual(GA2.Errors, null);
        //}


        //[TestMethod]
        //public void SearchElementWhichNotExist()   // Nagative testing
        //{
        //    // Arrange
        //    GotoHTMLControls();            
        //    GingerAction GA2 = new GingerAction("UIElementAction");

        //    // Act            
        //    mSeleniumDriver.UIElementAction(GA2, eElementType.TextBox, eLocateBy.Id, "YouCantFindMeButTrySearching", eElementAction.SetValue, "123");

        //    // Assert                        
        //    Assert.IsTrue(GA2.Errors != null);  // We want to verify some errors detected
        //    //TODO: verify the exact message we want or at least startwith..
        //}


        //[TestMethod]
        //public void SCMTest()
        //{
        //    // Arrange
        //    GotoHTMLControls();
        //    GingerAction GA2 = new GingerAction("UIElementAction");
        //    GingerAction GA3 = new GingerAction("UIElementAction");

        //    // Act            
        //    mSeleniumDriver.UIElementAction(GA2, eElementType.TextBox, eLocateBy.Id, "UserName", eElementAction.SetValue, "Yaron");
        //    mSeleniumDriver.UIElementAction(GA3, eElementType.TextBox, eLocateBy.Id, "Password", eElementAction.SetValue, "aaa");
        //    //TODO: find how to click sub,it button using css
        //   // mSeleniumDriver.UIElementAction(GA3, eElementType.Button, eLocateBy.Text, "Login", eElementAction.Click);
            

        //    // Assert
        //    //Assert.AreEqual(GA1.ExInfo, "Navigated to: " + GA1.URL);            
        //    Assert.AreEqual(GA2.Errors, null);
        //    // Assert.AreEqual(GA3.Errors, null);
        //}

        [TestMethod]
        public void VerifyNameSpaces()
        {
            // Arrange

            Assembly assembly = typeof(SeleniumDriver).Assembly;
            var namespaces = assembly.GetTypes()
                         .Select(t => t.Namespace)
                         .Distinct();

            // Act



            // Assert

            

            foreach (string ns in namespaces)
            {                                
                Assert.IsTrue(ns == "Amdocs.Ginger.SeleniumPlugin" || ns.StartsWith("Amdocs.Ginger.SeleniumPlugin."));                
            }
            
        }


        //[TestMethod]
        //public void Record()
        //{
        //    // Arrange            
        //    GotoHTMLControls();
            
        //    // Act
        //    mSeleniumDriver.StartRecording();

        //    // Assert            
        //    // ?????????????????
        //}

        //[TestMethod]
        //public void GetVisibleElements()
        //{
        //    // Arrange            
        //    GotoHTMLControls();
            

        //    // Act
        //    List<UIElement> list = mSeleniumDriver.GetVisibleElements();
            

        //    // Assert            
        //    // ?????????????????
        //}



        //[TestMethod]
        //public void TakeScreenShot()
        //{
        //    // Arrange
        //    GotoHTMLControls();
        //    GingerAction GA = new GingerAction("Take Screen Shot");            

        //    // Act            
        //    mSeleniumDriver.TakeScreenShot(GA, eScreens.Active);
            
        //    string filename = @"c:\temp\1.jpg";
        //    byte[] bytes = GA.Output.getBytes("SC1");
        //    System.IO.File.WriteAllBytes(filename, bytes);

        //    // Assert            
        //    Assert.AreEqual(GA.Errors, null);
        //    Assert.AreEqual(GA.Output.Values.Count, 1);

        //}

        //[TestMethod]
        //public void GetLabelValueByXpath()
        //{
        //    // Arrange
        //    GotoHTMLControls();
        //    GingerAction GA = new GingerAction("UIElementAction");            

        //    // Act            
        //    mSeleniumDriver.UIElementAction(GA, eElementType.Button, eLocateBy.XPath, "/html/body/div[6]/label[2]", eElementAction.GetValue);

        //    string txt = GA.Output["Text"];
                
        //    // Assert            
        //    Assert.AreEqual(GA.Errors, null);
        //    Assert.AreEqual(GA.Output.Values.Count, 1);
        //    Assert.AreEqual(GA.Output.Values[0].Param , "Text");
        //    Assert.AreEqual(GA.Output.Values[0].ValueString, "Hello World");

        //}

    }
}
