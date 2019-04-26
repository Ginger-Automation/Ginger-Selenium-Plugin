
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

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Service = new SeleniumChromeService();
            Service.StartSession();
            string url = Path.Combine(TestResources.GetTestResourcesFolder("HTML"), "HTMLControls.html");
            Service.BrowserActions.Navigate(url);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Service.StopSession();
        }


        [TestMethod]
        public void LocateElementByCSS()
        {
            //Button Element = Service.LocatLWebElement.LocateElementByCss("#test8 > div > label") as GingerWebElement;

            //Assert.AreEqual("*** Button ***", Element. .WebElement.Text);
        }

        //[TestMethod]
        //public void LocateElementByID()

        //{
        //    GingerWebElement Element = ElementLocator.LocateElementByID("button1") as GingerWebElement;

        //    Assert.AreEqual("button 1", Element.WebElement.GetAttribute("value"));
        //}


        [TestMethod]
        public void LocateElementByLinkTest()
        {
            //GingerWebElement Element = Service.LocatLWebElement.LocateElementByPartiallinkText<GingerWebElement>("This is A Link to Google, Click me") as GingerWebElement;

            //Assert.AreEqual("http://www.google.com/", Element.WebElement.GetAttribute("href"));
        }
        [TestMethod]
        public void LocateElementByPartiallinkText()
        {

            //GingerWebElement Element = Service.LocatLWebElement.LocateElementByPartiallinkText<GingerWebElement>("Ginger") as GingerWebElement;

            //Assert.AreEqual("Ginger Spice It Up!", Element.WebElement.Text);
        }
    
        [TestMethod]
        public void LocateElementByTag()
        {

        //    GingerWebElement Element = Service.LocatLWebElement.LocateElementByTag<GingerWebElement>("H2") as GingerWebElement;

        //    Assert.AreEqual("Make me Green !", Element.WebElement.Text);
        }

        [TestMethod]
        public void LocateElementByXPath()
        {
            GingerWebElement Element = Service.LocatLWebElement.LocateElementByXPath(ElementType.WebElement, "/html/body/table/tbody/tr[2]/td[5]") as GingerWebElement;

            // Assert.AreEqual("217-811-2932", Element.GetAttribute(); // .WebElement.Text);
        }
        [TestMethod]
        public void LocateElementsByClassName()
        {
            int eLEMENTcOUNT = Service.LocatLWebElement.LocateElementsByClassName("TestDescription").Count;
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
            int ElementsCount = Service.LocatLWebElement.LocateElementsByTagName("a").Count;
            Assert.AreEqual(4, ElementsCount);
        }

        [TestMethod]
        public void SetTextBoxText()
        {
            // Arrange            
            string txt = "123";

            //Act
            ITextBox GWE = (ITextBox)Service.LocatLWebElement.LocateElementByID( ElementType.TextBox, "GingerPhone");
            GWE.SetText(txt);
            string value = GWE.GetText();

            //Assert
            Assert.AreEqual(txt, value, "Set value and get value are equel");
        }


        [TestMethod]
        public void GetElem()
        {
            // Arrange            
            

            //Act
            IGingerWebElement GWE = Service.LocatLWebElement.LocateElementByID( ElementType.WebElement, "GingerPhone");
            int value = GWE.GetWidth();

            //Assert
            // Assert.AreEqual(txt, value, "Set value and get value are equel");
        }


        [TestMethod]
        public void SetTextBoxTextTwice()
        {
            // arrange
            string txt1 = "123";
            string txt2 = "456";

            //Act
            ITextBox GWE = (ITextBox)Service.LocatLWebElement.LocateElementByID( ElementType.TextBox, "GingerPhone");
            GWE.SetText(txt1);
            GWE.SetText(txt2);
            string value = GWE.GetText();

            //Assert
            Assert.AreEqual(txt2, value, "Set value and get value are equel");
        }



        

    }

}

