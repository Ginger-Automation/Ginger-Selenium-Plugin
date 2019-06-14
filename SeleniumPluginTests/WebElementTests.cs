using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace SeleniumPluginTests
{
    [TestClass]
    public class WebElementTests
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
        public void DragAndDrop()
        {
            try
            {
                Service.BrowserActions.Navigate("https://www.seleniumeasy.com/test/drag-and-drop-demo.html", "Current");

                GingerWebElement Element = Service.LocateWebElement.LocateElementByXPath(eElementType.WebElement, "//*[@id=\"todrag\"]/span[1]") as GingerWebElement;
                GingerWebElement Target = Service.LocateWebElement.LocateElementByID(eElementType.WebElement, "mydropzone") as GingerWebElement;
                Element.DragAndDrop("DragDropJS", Target);

                GingerWebElement validation = Service.LocateWebElement.LocateElementByXPath(eElementType.Span, "//*[@id=\"droppedlist\"]/span") as GingerWebElement;
                Assert.AreEqual("Draggable 1", validation.GetAttribute("innerHTML"));
            }
            finally
            {
                //cleanup
                string url = Path.Combine(TestResources.GetTestResourcesFolder("HTML"), "HTMLControls.html");
                Service.BrowserActions.Navigate(url, "Current");
            }
        }
        [TestMethod]
        public void GetAttribute()
        {
            GingerWebElement Element = Service.LocateWebElement.LocateElementByXPath(eElementType.WebElement, "//*[@id=\"test7\"]/a") as GingerWebElement;
            Assert.AreEqual("http://www.google.com/", Element.GetAttribute("href"));
        }
        [TestMethod]
        public void GetHeight()
        {
            GingerWebElement Element = Service.LocateWebElement.LocateElementByXPath(eElementType.WebElement, "//*[@id=\"test7\"]/a") as GingerWebElement;
            Assert.AreNotEqual(0, Element.GetHeight());
        }
        [Ignore]
        [TestMethod]
        public void GetItemCount()
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public void GetSize()
        {
            GingerWebElement Element = Service.LocateWebElement.LocateElementByXPath(eElementType.WebElement, "//*[@id=\"test7\"]/a") as GingerWebElement;

            Size size = Element.GetSize();

            Assert.AreNotEqual(0, size.Height);
            Assert.AreNotEqual(0, size.Width);
        }

    
        [TestMethod]
        public void GetWidth()
        {
            GingerWebElement Element = Service.LocateWebElement.LocateElementByXPath(eElementType.WebElement, "//*[@id=\"test7\"]/a") as GingerWebElement;
            Assert.AreNotEqual(0, Element.GetWidth());
        }

        [TestMethod]
        public void Hover()
        {
            GingerWebElement Element = Service.LocateWebElement.LocateElementByXPath(eElementType.WebElement, "//*[@id=\"test7\"]/a") as GingerWebElement;
            Element.Hover();
        }

        [TestMethod]

        public void IsEnabled()
        {
            GingerWebElement Element = Service.LocateWebElement.LocateElementByXPath(eElementType.WebElement, "//*[@id=\"submitformtest\"]/input[2]") as GingerWebElement;

            Assert.AreEqual(false, Element.IsEnabled());
        }
        [TestMethod]
        public void IsVisible()
        {
            GingerWebElement Element = Service.LocateWebElement.LocateElementByXPath(eElementType.WebElement, "//*[@id=\"invisible\"]") as GingerWebElement;

            Assert.AreEqual(false, Element.IsVisible());
        }
        [TestMethod]
        public void RightClick()
        {
            GingerWebElement Element = Service.LocateWebElement.LocateElementByXPath(eElementType.WebElement, "//*[@id=\"chk11\"]") as GingerWebElement;

            Element.RightClick();
            GingerWebElement validation = Service.LocateWebElement.LocateElementByXPath(eElementType.WebElement, "//*[@id=\"clickedright\"]") as GingerWebElement;
            Assert.AreEqual("clicked right", validation.GetAttribute("innerHTML"));
        }



    }
}
