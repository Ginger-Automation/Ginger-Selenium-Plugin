using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Tests.Elements
{
    [Ignore]
    [TestClass]
    class SpanTest
    {


        static SeleniumServiceBase Service = null;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Service = new SeleniumChromeService();
            Service.StartSession();
            string url = Path.Combine(TestResources.GetTestResourcesFolder("HTML"), "HTMLControls.html");
            Service.BrowserActions.Navigate(url, "Current");
        }
        [ClassCleanup]
        public static void CleanUp()
        {
            Service.StopSession();

        }

        [TestMethod]
        public void GetValue()
        {
            Assert.Fail();
        }
        [TestMethod]
        public void SetValue(string Text)
        {

            Assert.Fail();
        }
    }
}
