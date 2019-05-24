using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using Ginger.Plugin.Platform.Web;
using Ginger.Plugin.Platform.Web.Elements;

namespace SeleniumPluginTests
{
    [TestClass]
  public  class ChromeTests
    {
        static SeleniumServiceBase Service = null;
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Service = new SeleniumChromeService();

            Service.StartSession();
        }

        [ClassCleanup]

        public static void CleanUp()
        {
            Service.StopSession();

        }

        [TestMethod]
        public void CloseWindow()
        {
            Service.BrowserActions.CloseWindow();

            Assert.AreEqual(0, Service.Driver.WindowHandles.Count);
            Service.StartSession();
        }

      
        [TestMethod]
        public void ExecuteScript()
        {
            Service.StartSession();
        }

   
        [TestMethod]
        public void FullScreen()

        {
            Service.BrowserActions.FullScreen();
        }

        [TestMethod]
        public void  GetCurrentUrl()
        {

            Service.StartSession();
        }

        [TestMethod]
        public void GetTitle()
        {

            Service.BrowserActions.Navigate("https://github.com/Ginger-Automation","Current");
            string Actual = Service.BrowserActions.GetTitle();
            Assert.AreEqual("Ginger-Automation", Actual);

        }

        [TestMethod]
        public void GetWindowHandle()
        {
            string handle=Service.BrowserActions.GetWindowHandle();

            Assert.AreNotEqual(null, handle);
        }

        [TestMethod]
        public IReadOnlyCollection<string> GetWindowHandles()
        {
           throw new NotImplementedException();
        }

        [TestMethod]
        public void Maximize()
        {
            Service.BrowserActions.Maximize();
        }

        [TestMethod]
        public void Minimize()
        {
            Service.BrowserActions.Maximize();
        }

        [TestMethod]
        public void NavigateBack()
        {
            string CurrentUrl =@"https://github.com/Ginger-Automation";
            Service.BrowserActions.Navigate(CurrentUrl, "Current");
            Service.BrowserActions.Navigate(@"https://github.com", "Current");

            Service.BrowserActions.NavigateBack();

            Assert.AreEqual(CurrentUrl, Service.BrowserActions.GetCurrentUrl());
        }

        [TestMethod]
        public void NavigateForward()
        {

            string CurrentUrl = @"https://github.com/Ginger-Automation";
            Service.BrowserActions.Navigate(CurrentUrl, "Current");
    
            Service.BrowserActions.Navigate(@"https://github.com", "Current");
            Service.BrowserActions.Navigate(@"https://github.com/Ginger-Automation/Ginger", "Current");
            Service.BrowserActions.NavigateBack();
            Service.BrowserActions.NavigateBack();

            Service.BrowserActions.NavigateForward();
            Assert.AreEqual("https://github.com/", Service.BrowserActions.GetCurrentUrl());
        }

        [TestMethod]
        public void Refresh()
        {
            string CurrentUrl = @"https://github.com/Ginger-Automation";
            Service.BrowserActions.Navigate(CurrentUrl, "Current");

            Service.BrowserActions.Refresh();
            Assert.AreEqual(CurrentUrl, Service.BrowserActions.GetCurrentUrl());
        }


        [TestMethod]
        public void SwitchToFrame(IGingerWebElement WebElement)
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void SwitchToParentFrame()
        {
           throw new NotImplementedException();
        }
    }
}
