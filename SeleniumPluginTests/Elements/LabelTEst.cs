using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Ginger.Plugins.Web.SeleniumPlugin.Tests.Elements
{
    [TestClass]
   public class LabelTest
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
        public void GetFont()
        {
            Label Element = Service.LocateWebElement.LocateElementByXPath(eElementType.Label, "//*[@id=\"test2\"]/label") as Label;
            Element.GetFont();

        }

        [TestMethod]
        public void GetText()
        {
            Label Element = Service.LocateWebElement.LocateElementByXPath(eElementType.Label, "//*[@id=\"test2\"]/label") as Label;
            string result = Element.GetText();
            Assert.AreEqual(@"2. Button without id - Click me", result);
        }
        [TestMethod]
        public void Getvalue()
        {
            Label Element = Service.LocateWebElement.LocateElementByXPath(eElementType.Label, "//*[@id=\"test2\"]/label") as Label;


            Assert.AreEqual(@"2. Button without id - Click me", Element.Getvalue());
        }
    }
}
