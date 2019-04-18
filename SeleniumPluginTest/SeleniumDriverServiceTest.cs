using Amdocs.Ginger.Plugin.Core;
using Amdocs.Ginger.Plugin.Core.ActionsLib;
using GingerSeleniumPlugin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static Amdocs.Ginger.Plugin.Core.ActionsLib.ActInfo;

namespace SeleniumPluginTest
{
    [TestClass]
    public class SeleniumDriverServiceTest
    {
       static SeleniumChromeService service = null;

        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
           service = new SeleniumChromeService();

            service.StartDriver();
        }

        [ClassCleanup]
        public static void ClassCleanup(TestContext tc)
        {
            service = new SeleniumChromeService();

            service.StopSession();
        }


        [TestMethod]
        public void UIElementDragnDropJsTest()
        {
            service.webDriver.Url = @"https://www.w3schools.com/html/html5_draganddrop.asp";

            ActUIElementInfo act = new ActUIElementInfo();

            act.LocateBy = ActInfo.eLocateBy.ByXPath;
            act.LocateValue= "//*[@id=\"drag1\"]";
            act.ElementAction = eElementAction.DragDrop;
            act.DragDropType = eElementDragDropType.DragDropJS;
            act.TargetLocateBy = eLocateBy.ByXPath;

            act.TargetLocateValue= "//*[@id=\"div2\"]";

            GingerAction GA = new GingerAction();
            service.PerformUIElementAction(GA, act);

            Assert.AreEqual(true, string.IsNullOrEmpty(GA.Errors));
        }

        [TestMethod]
        public void UIElementDragnDropSeleniumTest()
        {
            service.webDriver.Url = @"https://demos.telerik.com/kendo-ui/dragdrop/index";

            ActUIElementInfo act = new ActUIElementInfo();

            act.LocateBy = ActInfo.eLocateBy.ByXPath;
            act.LocateValue = "//*[@id='draggable']";
            act.ElementAction = eElementAction.DragDrop;
            act.DragDropType = eElementDragDropType.DragDropSelenium;
            act.TargetLocateBy = eLocateBy.ByXPath;

            act.TargetLocateValue = "//*[@id='droptarget']";

            GingerAction GA = new GingerAction();
            service.PerformUIElementAction(GA, act);

            Assert.AreEqual(true, string.IsNullOrEmpty(GA.Errors));
        }


        [TestMethod]
        public void UIElementClickHyperLink()
        {
            service.webDriver.Url = @"http://the-internet.herokuapp.com/";

            ActUIElementInfo act = new ActUIElementInfo();

            act.LocateBy = ActInfo.eLocateBy.ByXPath;
            act.LocateValue = "//*[@id=\"content\"]/ul/li[1]/a";

            act.ElementType = eElementType.HyperLink;
            act.ElementAction = eElementAction.Click;
          
            GingerAction GA = new GingerAction();
            service.PerformUIElementAction(GA, act);

            Assert.AreEqual(@"http://the-internet.herokuapp.com/abtest", service.webDriver.Url);
        }

        [TestMethod]
        public void UIElementButtonClick()
        {
            service.webDriver.Url = @"https://www.w3schools.com/html/tryit.asp?filename=tryhtml_form_submit";
            GingerAction GA = new GingerAction();

            ActBrowserInfo BrowserAction = new ActBrowserInfo();
            BrowserAction.ControlAction = eControlAction.SwitchFrame;
            BrowserAction.LocateBy = eLocateBy.ByID;
            BrowserAction.LocateValue = "iframeResult";

            service.HandleBrowserElementAction(GA, BrowserAction);

            ActUIElementInfo act = new ActUIElementInfo();

            act.LocateBy = ActInfo.eLocateBy.ByXPath;
            act.LocateValue = @"/html/body/form/input[3]";

            act.ElementType = eElementType.Button;
            act.ElementAction = eElementAction.ClickAndValidate;
            act.ClickType = eElementAction.Click;
            act.ValidationType = eElementAction.IsVisible;
            act.ValidationElementLocateby = eLocateBy.ByXPath;
            act.ValidationElementLocatorValue = @"/html/body/div[1]";
          

            service.PerformUIElementAction(GA, act);

            Assert.AreEqual(true, string.IsNullOrEmpty(GA.Errors));
        }

    }

}
