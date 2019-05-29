using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Ginger.Plugins.Web.SeleniumPlugin.Tests.Elements
{
    [TestClass]
    public class CanvasTest
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
        public void ClickXY(int x, int y)
        {
            throw new System.NotImplementedException();
        }


        [TestMethod]
        public void DrawObject()
        {
            object before = Service.BrowserActions.ExecuteScript("document.getElementsByTagName(\"canvas\")[0].toDataURL()");
            Service.BrowserActions.Navigate(@"https://szimek.github.io/signature_pad/", "Current");


            Canvas Element = Service.LocateWebElement.LocateElementByXPath(eElementType.Canvas, "//*[@id='signature-pad']/div[1]/canvas") as Canvas;

            Element.DrawObject();

            object after = Service.BrowserActions.ExecuteScript("signaturePad.isEmpty()");

            Assert.AreNotEqual(after, before);
        }
    }
}
