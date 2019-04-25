
using System;
using System.Collections.Generic;
using System.Text;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using Ginger.Plugin.Platform.Web;
using Ginger.Plugin.Platform.Web.Elements;
using System.IO;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amdocs.Ginger.Plugin.Core;
using Ginger.Plugins.Web.SeleniumPlugin.Elements;
using OpenQA.Selenium;

namespace SeleniumPluginTests
{
    [TestClass]
  public  class LocateWebElementsTests
    {

        static SeleniumServiceBase Service = null;
        static ILocateWebElement ElementLocator = null;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Service = new SeleniumChromeService();
            Service.StartSession();
            Service.Driver.Url = Path.Combine(TestResources.GetTestResourcesFolder("HTML"), "HTMLControls.html");
            ElementLocator = new LocateWebElements(Service);

        }

        [TestMethod]
        public void LocateElementByCSS()
        {
            GingerWebElement Element = ElementLocator.LocateElementByCSS("#test8 > div > label") as GingerWebElement;

            Assert.AreEqual("*** Button ***", Element.WebElement.Text);
        }

        [TestMethod]
        public void LocateElementByID()

        {
            GingerWebElement Element = ElementLocator.LocateElementByID("button1") as GingerWebElement;

            Assert.AreEqual("button 1", Element.WebElement.GetAttribute("value"));
        }


        [TestMethod]
        public void LocateElementByLinkTest()
        {
            GingerWebElement Element = ElementLocator.LocateElementByPartiallinkText("This is A Link to Google, Click me") as GingerWebElement;

            Assert.AreEqual("http://www.google.com/", Element.WebElement.GetAttribute("href"));
        }
        [TestMethod]
        public void LocateElementByPartiallinkText()
        {

            GingerWebElement Element = ElementLocator.LocateElementByPartiallinkText("Ginger") as GingerWebElement;

            Assert.AreEqual("Ginger Spice It Up!", Element.WebElement.Text);
        }
    
        [TestMethod]
        public void LocateElementByTag()
        {

            GingerWebElement Element = ElementLocator.LocateElementByTag("H2") as GingerWebElement;

            Assert.AreEqual("Make me Green !", Element.WebElement.Text);
        }

        [TestMethod]
        public void LocateElementByXPath()
        {
            GingerWebElement Element = ElementLocator.LocateElementByXPath("/html/body/table/tbody/tr[2]/td[5]") as GingerWebElement;

            Assert.AreEqual("217-811-2932", Element.WebElement.Text);
        }
        [TestMethod]
        public void LocateElementsByClassName()
        {
            int eLEMENTcOUNT = ElementLocator.LocateElementsByClassName("TestDescription").Count;
            Assert.AreEqual(23, eLEMENTcOUNT);
        }
        [TestMethod]
        public void LocateElementsbyCSS()
        {
            Assert.Fail();

        }
        [TestMethod]
        public void LocateElementsByTagName()
        {
            int ElementsCount = ElementLocator.LocateElementsByTagName("a").Count;
            Assert.AreEqual(4, ElementsCount);
        }

        [TestMethod]
        public void TestMethod1()
        {
           /* WebTextBox GWE = ElementLocator.LocateElementByID("GingerPhone");
            WebTextBox Element = new WebTextBox(GWE.Element as IWebElement); 
            Element.SetText("test");
            */
        }


        [ClassCleanup]
        public static void CleanUp()
        {
            Service.StopSession();
        }

    }

}

