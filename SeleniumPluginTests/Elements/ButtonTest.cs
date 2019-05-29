using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


namespace Ginger.Plugins.Web.SeleniumPlugin.Tests.Elements
{
    [TestClass]
    public class ButtonTest
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
            Button Element = Service.LocateWebElement.LocateElementByXPath(eElementType.Button, "//*[@id=\"test2\"]/input") as Button;
            Assert.AreEqual("",Element.GetValue());
        }
        [TestMethod]
        public void JavascriptClick()
        {
            Service.BrowserActions.Refresh();
           Button Element = Service.LocateWebElement.LocateElementByXPath(eElementType.Button, "//*[@id=\"test2\"]/input") as Button;

            Element.JavascriptClick();
            Label label = Service.LocateWebElement.LocateElementByXPath(eElementType.Label, "//*[@id=\"test2\"]/input") as Label;
            Assert.AreEqual(true, label.IsVisible());
        }
        [TestMethod]
        public void Click()
        {
            Service.BrowserActions.Refresh();
            Button Element = Service.LocateWebElement.LocateElementByXPath(eElementType.Button, "//*[@id=\"test2\"]/input") as Button;

            Element.Click();
            Label label = Service.LocateWebElement.LocateElementByXPath(eElementType.Label, "//*[@id=\"test2\"]/input") as Label;
            Assert.AreEqual(true, label.IsVisible());
        }


        [TestMethod]
            public void DoubleClick()
        {
            Service.BrowserActions.Refresh();
            Button Element = Service.LocateWebElement.LocateElementByID(eElementType.Button, "button1") as Button;

            Element.DoubleClick();
            Label label = Service.LocateWebElement.LocateElementByID(eElementType.Label, "btn1labeldoubleclick") as Label;
            Assert.AreEqual(true, label.IsVisible());
        }
        [TestMethod]
        public void MultiClick()
        {
            throw new System.NotImplementedException();
        }
        [TestMethod]
        public void MouseClick()
        {
            Service.BrowserActions.Refresh();
            Button Element = Service.LocateWebElement.LocateElementByXPath(eElementType.Button, "//*[@id=\"test2\"]/input") as Button;

            Element.MouseClick();
            Label label = Service.LocateWebElement.LocateElementByXPath(eElementType.Label, "//*[@id=\"test2\"]/input") as Label;
            Assert.AreEqual(true, label.IsVisible());
        }
        [TestMethod]
        public void Submit()
        {
            Service.BrowserActions.Refresh();
            Button Element = Service.LocateWebElement.LocateElementByID(eElementType.Button, "SubmitButtonForm") as Button;

            Element.Submit();
            Label label = Service.LocateWebElement.LocateElementByID(eElementType.Label, "formsubmitted") as Label;
            Assert.AreEqual("Submitted", label.GetText());
        }
    }
}
