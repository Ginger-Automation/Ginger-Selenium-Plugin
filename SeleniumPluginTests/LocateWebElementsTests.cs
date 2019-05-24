
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
    public class LocateWebElementsTests
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
        public void LocateElementByCSS()
        {
            Button Element = Service.LocateWebElement.LocateElementByCss(eElementType.Button,"#test8 > div > label") as Button;

            Assert.AreEqual("*** Button ***", Element.GetValue());
        }

        [TestMethod]
        public void LocateElementByID()

        {
            GingerWebElement Element = Service.LocateWebElement.LocateElementByID(eElementType.WebElement,"button1") as GingerWebElement;

            Assert.AreEqual("button 1", Element.GetAttribute("value"));
        }


        [TestMethod]
        public void LocateElementByLinkTest()
        {
            GingerWebElement Element = Service.LocateWebElement.LocateElementByPartiallinkText(eElementType.WebElement,"This is A Link to Google, Click me") as GingerWebElement;

            Assert.AreEqual("http://www.google.com/", Element.GetAttribute("href"));
        }
        [TestMethod]
        public void LocateElementByPartiallinkText()
        {

            ILabel Element = Service.LocateWebElement.LocateElementByPartiallinkText(eElementType.Label,"Ginger") as ILabel;

            Assert.AreEqual("Ginger Spice It Up!", Element.GetText());
        }

        [TestMethod]
        public void LocateElementByTag()
        {

            ILabel Element = Service.LocateWebElement.LocateElementByTag(eElementType.Label,"H2") as ILabel;

            Assert.AreEqual("Make me Green !", Element.GetText());
        }

        [TestMethod]
        public void LocateElementByXPath()
        {
            ILabel Element = Service.LocateWebElement.LocateElementByXPath(eElementType.Label, "/html/body/table/tbody/tr[2]/td[5]") as ILabel;

            Assert.AreEqual("217-811-2932", Element.GetText()); // .WebElement.Text);
        }
        [TestMethod]
        public void LocateElementsByClassName()
        {
            Assert.Fail();
            //int eLEMENTcOUNT = Service.LocateWebElement.LocateElementsByClassName("TestDescription").Count;
            //Assert.AreEqual(23, eLEMENTcOUNT);
        }
        [TestMethod]
        public void LocateElementsbyCSS()
        {
            Assert.Fail();

        }
        [TestMethod]
        public void LocateElementsByTagName()
        {
            Assert.Fail();
            //int ElementsCount = Service.LocateWebElement.LocateElementsByTagName("a").Count;
            //Assert.AreEqual(4, ElementsCount);
        }

        [TestMethod]
        public void SetTextBoxText()
        {
            //Arrange
            string txt = "123";

            //Act
            ITextBox GWE = (ITextBox)Service.LocateWebElement.LocateElementByID(eElementType.TextBox, "GingerPhone");
            GWE.SetText(txt);
            string value = GWE.GetText();

          //  Assert
            Assert.AreEqual(txt, value, "Set value and get value are equel");
        }


        [TestMethod]
        public void GetElem()
        {
            //Arrange

            string txt = "123";
            //Act
            IGingerWebElement GWE = Service.LocateWebElement.LocateElementByID(eElementType.WebElement, "GingerPhone");
    

            //Assert
             Assert.AreNotEqual(null, GWE.Element);
        }


        [TestMethod]
        public void SetTextBoxTextTwice()
        {
            //arrange
            string txt1 = "123";
            string txt2 = "456";

            //Act
            ITextBox GWE = (ITextBox)Service.LocateWebElement.LocateElementByID(eElementType.TextBox, "GingerPhone");
            GWE.SetText(txt1);
            GWE.SetText(txt2);
            string value = GWE.GetText();

           //Assert
            Assert.AreEqual(txt2, value, "Set value and get value are equel");
        }





    }

}

