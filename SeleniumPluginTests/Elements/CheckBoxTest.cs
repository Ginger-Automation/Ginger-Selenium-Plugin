using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


namespace Ginger.Plugins.Web.SeleniumPlugin.Tests.Elements
{
    [TestClass]
    public class CheckBoxTest
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
            CheckBox Element = Service.LocateWebElement.LocateElementByID(eElementType.CheckBox, "chk11") as CheckBox;
            Element.JavascriptClick();
            Label label = Service.LocateWebElement.LocateElementByID(eElementType.Label, "checkboxclicked") as Label;
            Assert.AreEqual("value changed", label.GetText());
      
        }
        [TestMethod]
        public void Click()
        {
            Service.BrowserActions.Refresh();
            CheckBox Element = Service.LocateWebElement.LocateElementByID(eElementType.CheckBox, "chk11") as CheckBox;
            Element.Click();
            Label label = Service.LocateWebElement.LocateElementByID(eElementType.Label, "checkboxclicked") as Label;
            Assert.AreEqual("value changed", label.GetText());

        }
        [TestMethod]
        public void GetValue()
        {
            Service.BrowserActions.Refresh();
            CheckBox Element = Service.LocateWebElement.LocateElementByID(eElementType.CheckBox, "chk11") as CheckBox;
  
           
            Assert.AreEqual("chk1 - value", Element.GetValue());
        }

        [TestMethod]
        public void DoubleClick()
        {
            Service.BrowserActions.Refresh();
            CheckBox Element = Service.LocateWebElement.LocateElementByID(eElementType.CheckBox, "chk11") as CheckBox;
            Element.Click();
            Label label = Service.LocateWebElement.LocateElementByID(eElementType.Label, "checkboxclicked") as Label;
            Assert.AreEqual("value changed", label.GetText());
        }
        [Ignore]
        [TestMethod]
        public void MultiClick()
        {
            Service.BrowserActions.Refresh();
            CheckBox Element = Service.LocateWebElement.LocateElementByID(eElementType.CheckBox, "chk11") as CheckBox;
            Element.MultiClick();
            Label label = Service.LocateWebElement.LocateElementByID(eElementType.Label, "checkboxclicked") as Label;
            Assert.AreEqual("value changed", label.GetText());



        }
    
      
    }
}
