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
        }

        [TestMethod]
        public void StartSessionTest()
        {
            Service.StartDriver();
        }
        
        [TestMethod]
        public void CloseWindow()
        {
            Service.BrowserActions.CloseWindow();

            Assert.AreEqual(0, Service.Driver.WindowHandles.Count);
            Service.StartDriver();
        }

      
        [TestMethod]
        public void ExecuteScript()
        {
           throw new NotImplementedException();
        }

   
        [TestMethod]
        public void FullScreen()
        {
           throw new NotImplementedException();
        }

        [TestMethod]
        public void  GetCurrentUrl()
        {

            
        }

        [TestMethod]
        public void GetTitle()
        {
           throw new NotImplementedException();
        }

        [TestMethod]
        public void GetWindowHandle()
        {
           throw new NotImplementedException();
        }

        [TestMethod]
        public IReadOnlyCollection<string> GetWindowHandles()
        {
           throw new NotImplementedException();
        }

        [TestMethod]
        public void Maximize()
        {
           throw new NotImplementedException();
        }

        [TestMethod]
        public void Minimize()
        {
           throw new NotImplementedException();
        }

        [TestMethod]
        public void NavigateBack()
        {
           throw new NotImplementedException();
        }

        [TestMethod]
        public void NavigateForward()
        {
           throw new NotImplementedException();
        }

        [TestMethod]
        public void Refresh()
        {
           throw new NotImplementedException();
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
