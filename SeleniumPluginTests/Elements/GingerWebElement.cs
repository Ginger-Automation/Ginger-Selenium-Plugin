using Ginger.Plugin.Platform.Web.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Ginger.Plugins.Web.SeleniumPlugin.Tests.Elements
{
    [TestClass]
    public class GingerWebElementTest
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

      
       

       

        public void DragAndDrop(string DragDropType, IGingerWebElement targetElement)
        {

            Assert.Fail();
                
        }

        public void GetAttribute(string attributeName)
        {
            Assert.Fail();
        }

        public void GetHeight()
        {
            Assert.Fail();
        }


        public void GetSize()
        {
            Assert.Fail();
        }

        public void GetStyle()
        {
            Assert.Fail();
        }

        public void GetWidth()
        {
            Assert.Fail();
        }

        public void Hover()
        {
            Assert.Fail();
        }

        public void IsEnabled()
        {
            Assert.Fail();
        }

        public void IsVisible()
        {
            Assert.Fail();
        }

        public void RightClick()
        {
            Assert.Fail();
        }

        public void RunJavascript(string script)
        {
            Assert.Fail();
        }

        public void ScrollToElement()
        {
            Assert.Fail();
        }

        public void SetFocus()
        {
            Assert.Fail();
        }


        #region Common StaticClick Functions



       internal void Click(IWebElement clickElement)
        {

            Assert.Fail();
        }
        internal static void MouseClick(IWebElement clickElement, IWebDriver Driver)
        {
            Assert.Fail();
        }
 

        internal static void  DoubleClick(IWebElement clickElement,IWebDriver Driver)
        {
            Assert.Fail();

        }

        internal static void JavascriptClick(IWebElement clickElement, IWebDriver Driver)
        {
            Assert.Fail();
        }

        #endregion



        #region Common CLombobox/List functions 

        public void GetDropDownListOptions(IWebElement e)
        {
            Assert.Fail();
        }
        public  void ClearList(IWebElement e)
        {
            Assert.Fail();
        }


        public void CheckValuePopulated(IWebElement e)
        {
            Assert.Fail();
        }

        public void SelectElement(IWebElement we, string Value)
        {
            Assert.Fail();
        }

        public  void SelecElementByIndex(IWebElement we,int index)
        {
            SelectElement se = new SelectElement(we);
            se.SelectByIndex(index);
        }

        public  void SelectElementByText(IWebElement we,string Text)
        {
            Assert.Fail();
        }
        public  void SelectElementByValue(IWebElement we, string Text)
        {
            Assert.Fail();
        }




        #endregion

    }
}
