using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
        }

        [ClassCleanup]

        public static void CleanUp()
        {
            Service.StopSession();

        }

        [TestMethod]
        public void DragAndDrop()
        {
            throw new NotImplementedException();

        }
        [TestMethod]
        public void GetAttribute()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void GetHeight()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void GetItemCount()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void GetSize()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void GetStyle()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void GetWidth()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void Hover()
        {
           throw new NotImplementedException();
        }

        [TestMethod]

        public bool IsEnabled()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public bool IsVisible()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void RightClick()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void RunJavascript()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void ScrollToElement()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void SetDiabled()
        {
           throw new NotImplementedException();
        }
        [TestMethod]
        public void SetFocues()
        {
           throw new NotImplementedException();
        }
    }
}
