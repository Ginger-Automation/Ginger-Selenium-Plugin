using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Ginger.Plugins.Web.SeleniumPlugin.Tests.Elements
{
    [TestClass]
    public class ListTest
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

        [Ignore]
        [TestMethod]
        public void ClearValue()
        {
            SeleniumPlugin.Elements.List ELement = Service.LocateWebElement.LocateElementByID(eElementType.List, "sel1") as SeleniumPlugin.Elements.List;
            ELement.SelectByIndex(0);

            ELement.ClearValue();

            ELement.GetValue();
        }
        [TestMethod]
        public void GetValidValue()
        {

            SeleniumPlugin.Elements.List ELement = Service.LocateWebElement.LocateElementByID(eElementType.List, "sel1") as SeleniumPlugin.Elements.List;
  
            Assert.AreEqual(5, ELement.GetValidValue().Count);

        }
        [TestMethod]
        public void GetValue()
        {
            SeleniumPlugin.Elements.List ELement = Service.LocateWebElement.LocateElementByID(eElementType.List, "sel1") as SeleniumPlugin.Elements.List;
            ELement.SelectByIndex(2);
           
            Assert.AreEqual("Got It!", ELement.GetValue());
        }
        [TestMethod]
        public void IsValuePopulated()
        {
            SeleniumPlugin.Elements.List ELement = Service.LocateWebElement.LocateElementByID(eElementType.List, "sel1") as SeleniumPlugin.Elements.List;
            ELement.SelectByIndex(2);

            Assert.AreEqual("Got It!", ELement.GetValue());

        }
        [TestMethod]
        public void Select()
        {


            SeleniumPlugin.Elements.List ELement = Service.LocateWebElement.LocateElementByID(eElementType.List, "sel1") as SeleniumPlugin.Elements.List;
            ELement.Select("Got It!");

            Assert.AreEqual("Got It!", ELement.GetValue());
        }
        [TestMethod]
        public void SelectByIndex()
        {
            SeleniumPlugin.Elements.List ELement = Service.LocateWebElement.LocateElementByID(eElementType.List, "sel1") as SeleniumPlugin.Elements.List;
            ELement.SelectByIndex(2);

            Assert.AreEqual("Got It!", ELement.GetValue());

        }
        [TestMethod]
        public void SelectByText()
        {
            SeleniumPlugin.Elements.List ELement = Service.LocateWebElement.LocateElementByID(eElementType.List, "sel1") as SeleniumPlugin.Elements.List;
            ELement.SelectByText("Got It!"); 

            Assert.AreEqual("Got It!", ELement.GetValue());
        }
    }
}
