using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeleniumPluginTests.Elements
{
    [TestClass]
    public class TextBoxTests
    {
        static SeleniumServiceBase Service = null;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Service = new SeleniumFireFoxService();
            Service.StartSession();
            string url = Path.Combine(TestResources.GetTestResourcesFolder("HTML"), "HTMLControls.html");
            Service.BrowserActions.Navigate(url,"Current");
        }

        [TestMethod]
        public void ClearValue()
        {
            TextBox TB = (TextBox)Service.LocateWebElement.LocateElementByID(eElementType.TextBox, "GingerPhone");
            TB.SendKeys("ABCDE");

            TB.ClearValue();


            Assert.AreEqual(true, string.IsNullOrEmpty(TB.GetValue()));
        }
        [TestMethod]
        public void GetFont()
        {
            TextBox TB = (TextBox)Service.LocateWebElement.LocateElementByID(eElementType.TextBox, "GingerPhone");
        }
        [TestMethod]
        public void GetText()
        {
            TextBox TB = (TextBox)Service.LocateWebElement.LocateElementByID(eElementType.TextBox, "GingerPhone");
            TB.SetText("ABCDE");




            Assert.AreEqual("ABCDE", TB.GetValue());
        }
        [TestMethod]
        public void GetTextLength()
        {
            TextBox TB = (TextBox)Service.LocateWebElement.LocateElementByID(eElementType.TextBox, "GingerPhone");
            TB.SetText("ABCDE");




            Assert.AreEqual(5, TB.GetTextLength());
        }
        [TestMethod]
        public void GetValue()
        {
            TextBox TB = (TextBox)Service.LocateWebElement.LocateElementByID(eElementType.TextBox, "GingerPhone");
            TB.SetText("ABCDE");




            Assert.AreEqual("ABCDE", TB.GetValue());
        }
        [TestMethod]
        public void IsValuePopulated()
        {

            TextBox TB = (TextBox)Service.LocateWebElement.LocateElementByID(eElementType.TextBox, "GingerPhone");

            TB.SetText("ABCDE");
            Assert.AreEqual(true, TB.IsValuePopulated());


            TB.ClearValue();
            Assert.AreEqual(false, TB.IsValuePopulated());

        }

        [TestMethod]
        public void SendKeys()
        {

            TextBox TB = (TextBox)Service.LocateWebElement.LocateElementByID(eElementType.TextBox, "GingerPhone");
            TB.SetText("ABCDE");

            TB.SendKeys("FGH");


            Assert.AreEqual("ABCDEFGH", TB.GetValue());
        }
        [TestMethod]
        public void SetMultiValue()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void SetText()
        {
            TextBox TB = (TextBox)Service.LocateWebElement.LocateElementByID(eElementType.TextBox, "GingerPhone");
            TB.SendKeys("FGH");

            TB.SetText("ABCDE");




            Assert.AreEqual("ABCDE", TB.GetValue());
        }
        [TestMethod]
        public void SetValue()
        {
           throw new NotImplementedException();
        }
    }
}
