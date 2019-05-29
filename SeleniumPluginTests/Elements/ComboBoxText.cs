using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using Ginger.Plugins.Web.SeleniumPlugin.Elements;

namespace Ginger.Plugins.Web.SeleniumPlugin.Tests.Elements
{
    [TestClass]
    public class ComboBoxTest
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
        public void ClearValue()
        {
             ComboBox ELement = Service.LocateWebElement.LocateElementByID(eElementType.ComboBox, "sel1") as  ComboBox;
            ELement.SelectByIndex(0);

            ELement.ClearValue();

            ELement.GetValue();
        }
        [TestMethod]
        public void GetValidValue()
        {

             ComboBox ELement = Service.LocateWebElement.LocateElementByID(eElementType.ComboBox, "sel1") as  ComboBox;

            Assert.AreEqual(5, ELement.GetValidValue().Count);

        }
        [TestMethod]
        public void GetValue()
        {
             ComboBox ELement = Service.LocateWebElement.LocateElementByID(eElementType.ComboBox, "sel1") as  ComboBox;
            ELement.SelectByIndex(2);

            Assert.AreEqual("Got It!", ELement.GetValue());
        }
        [TestMethod]
        public void IsValuePopulated()
        {
             ComboBox ELement = Service.LocateWebElement.LocateElementByID(eElementType.ComboBox, "sel1") as  ComboBox;
            ELement.SelectByIndex(2);

            Assert.AreEqual("Got It!", ELement.GetValue());

        }
        [TestMethod]
        public void Select()
        {


             ComboBox ELement = Service.LocateWebElement.LocateElementByID(eElementType.ComboBox, "sel1") as  ComboBox;
            ELement.Select("Got It!");

            Assert.AreEqual("Got It!", ELement.GetValue());
        }
        [TestMethod]
        public void SelectByIndex()
        {
             ComboBox ELement = Service.LocateWebElement.LocateElementByID(eElementType.ComboBox, "sel1") as  ComboBox;
            ELement.SelectByIndex(2);

            Assert.AreEqual("Got It!", ELement.GetValue());

        }
        [TestMethod]
        public void SelectByText()
        {
             ComboBox ELement = Service.LocateWebElement.LocateElementByID(eElementType.ComboBox, "sel1") as  ComboBox;
            ELement.SelectByText("Got It!");

            Assert.AreEqual("Got It!", ELement.GetValue());
        }
    }
}
