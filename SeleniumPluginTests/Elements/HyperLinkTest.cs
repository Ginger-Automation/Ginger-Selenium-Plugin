using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Ginger.Plugins.Web.SeleniumPlugin.Tests.Elements
{
    [TestClass]
   public class HyperLinkTest
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
        public void JavascriptClick()
        {
            HyperLink Element = Service.LocateWebElement.LocateElementByXPath(eElementType.HyperLink, "/html/body/table/tbody/tr[3]/td[3]/a") as HyperLink;
            Element.JavascriptClick();

            GingerWebElement validation = Service.LocateWebElement.LocateElementByID(eElementType.WebElement, "test13") as GingerWebElement;
            string value = validation.GetAttribute("class");
            Assert.AreEqual("TestPass", value);

        }
        [TestMethod]
        public void Click()
        {
            HyperLink Element = Service.LocateWebElement.LocateElementByXPath(eElementType.HyperLink, "/html/body/table/tbody/tr[3]/td[3]/a") as HyperLink;
            Element.Click();

            GingerWebElement validation = Service.LocateWebElement.LocateElementByID(eElementType.WebElement, "test13") as GingerWebElement;
            string value = validation.GetAttribute("class");
            Assert.AreEqual("TestPass", value);
        }


        [TestMethod]
        public void DoubleClick()
        {
            HyperLink Element = Service.LocateWebElement.LocateElementByXPath(eElementType.HyperLink, "/html/body/table/tbody/tr[3]/td[3]/a") as HyperLink;
            Element.DoubleClick();

            GingerWebElement validation = Service.LocateWebElement.LocateElementByID(eElementType.WebElement, "test13") as GingerWebElement;
            string value = validation.GetAttribute("class");
            Assert.AreEqual("TestPass", value);
        }
        [TestMethod]
        public void MultiClick()
        {
            HyperLink Element = Service.LocateWebElement.LocateElementByXPath(eElementType.HyperLink, "/html/body/table/tbody/tr[3]/td[3]/a") as HyperLink;
            Element.MultiClick();

            GingerWebElement validation = Service.LocateWebElement.LocateElementByID(eElementType.WebElement, "test13") as GingerWebElement;
            string value = validation.GetAttribute("class");
            Assert.AreEqual("TestPass", value);
        }
        [TestMethod]
        public void MouseClick()
        {
            HyperLink Element = Service.LocateWebElement.LocateElementByXPath(eElementType.HyperLink, "/html/body/table/tbody/tr[3]/td[3]/a") as HyperLink;
            Element.MouseClick();

            GingerWebElement validation = Service.LocateWebElement.LocateElementByID(eElementType.WebElement, "test13") as GingerWebElement;
            string value = validation.GetAttribute("class");
            Assert.AreEqual("TestPass", value);
        }
    }
}
