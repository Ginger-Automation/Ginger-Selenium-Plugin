using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Ginger.Plugins.Web.SeleniumPlugin.Elements;

namespace Ginger.Plugins.Web.SeleniumPlugin.Tests.Elements
{
    [TestClass]
    public class RadioButtonTest
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
        public void JavascriptClick()
        {
            Service.BrowserActions.Refresh();
            RadioButton Element = Service.LocateWebElement.LocateElementByXPath(eElementType.RadioButton, "//*[@id=\"test18\"]/input[2]") as RadioButton;
            Element.JavascriptClick();
            object result = Service.BrowserActions.ExecuteScript("document.getElementsByName(\"country\")[1].checked");

            RadioButton Element2 = Service.LocateWebElement.LocateElementByXPath(eElementType.RadioButton, "//*[@id=\"test18\"]/input[2]") as RadioButton;

            Assert.AreEqual("true", Element2.GetAttribute("checked"));
        }
        [TestMethod]
        public void Click()
        {
            Service.BrowserActions.Refresh();
            RadioButton Element = Service.LocateWebElement.LocateElementByXPath(eElementType.RadioButton, "//*[@id=\"test18\"]/input[2]") as RadioButton;
            Element.Click();
            object result = Service.BrowserActions.ExecuteScript("document.getElementsByName(\"country\")[1].checked");

            RadioButton Element2 = Service.LocateWebElement.LocateElementByXPath(eElementType.RadioButton, "//*[@id=\"test18\"]/input[2]") as RadioButton;

            Assert.AreEqual("true", Element2.GetAttribute("checked"));
        }


        [TestMethod]
        public void DoubleClick()
        {
            Service.BrowserActions.Refresh();
            RadioButton Element = Service.LocateWebElement.LocateElementByXPath(eElementType.RadioButton, "//*[@id=\"test18\"]/input[2]") as RadioButton;
            Element.DoubleClick();
            object result = Service.BrowserActions.ExecuteScript("document.getElementsByName(\"country\")[1].checked");

            RadioButton Element2 = Service.LocateWebElement.LocateElementByXPath(eElementType.RadioButton, "//*[@id=\"test18\"]/input[2]") as RadioButton;

            Assert.AreEqual("true", Element2.GetAttribute("checked"));
        }
        [Ignore]
        [TestMethod]
        public void MultiClick()
        {
            Service.BrowserActions.Refresh();
            RadioButton Element = Service.LocateWebElement.LocateElementByXPath(eElementType.RadioButton, "//*[@id=\"test18\"]/input[2]") as RadioButton;
            Element.MultiClick();
            object result = Service.BrowserActions.ExecuteScript("document.getElementsByName(\"country\")[1].checked");

            RadioButton Element2 = Service.LocateWebElement.LocateElementByXPath(eElementType.RadioButton, "//*[@id=\"test18\"]/input[2]") as RadioButton;

            Assert.AreEqual("true", Element2.GetAttribute("checked"));
        }

        [TestMethod]
        public void MouseClick()
        {
            Service.BrowserActions.Refresh();
            RadioButton Element = Service.LocateWebElement.LocateElementByXPath(eElementType.RadioButton, "//*[@id=\"test18\"]/input[2]") as RadioButton;
            Element.MouseClick();
            object result = Service.BrowserActions.ExecuteScript("document.getElementsByName(\"country\")[1].checked");

            RadioButton Element2 = Service.LocateWebElement.LocateElementByXPath(eElementType.RadioButton, "//*[@id=\"test18\"]/input[2]") as RadioButton;

            Assert.AreEqual("true", Element2.GetAttribute("checked"));
        }
    }
}
