using Amdocs.Ginger.Plugin.Core;
using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    public class LocateWebElements : ILocateWebElement
    {

        SeleniumServiceBase DriverService { get; set; }
        public LocateWebElements(SeleniumServiceBase mService)
        {
            Service = mService;
        }

        public IServiceSession Service
        {
            get
            {
                return DriverService;
            }

            set
            {

                DriverService = value as SeleniumServiceBase;
            }
        }
        

        public IGingerWebElement LocateElementByCSS(string Css)
        {
          IWebElement element=  DriverService.Driver.FindElement(By.CssSelector(Css));

            return new GingerWebElement(element);
        }


        public IGingerWebElement LocateElementByID(string ID)
        {
            IWebElement element = DriverService.Driver.FindElement(By.Id(ID));

            return new GingerWebElement(element);
        }

        public IGingerWebElement LocateElementByLinkTest(string Linktext)
        {
            IWebElement element = DriverService.Driver.FindElement(By.LinkText(Linktext));

            return new GingerWebElement(element);
        }

        public IGingerWebElement LocateElementByPartiallinkText(string PartialLinkText)
        {
            IWebElement element = DriverService.Driver.FindElement(By.PartialLinkText(PartialLinkText));

            return new GingerWebElement(element);
        }

        public IGingerWebElement LocateElementByTag(string Tag)
        {
            IWebElement element = DriverService.Driver.FindElement(By.TagName(Tag));

            return new GingerWebElement(element);
        }

        public IGingerWebElement LocateElementByXPath(string Xpath)
        {
            IWebElement element = DriverService.Driver.FindElement(By.XPath(Xpath));

            return new GingerWebElement(element);
        }

        public List<IGingerWebElement> LocateElementsByClassName(string ClassName)
        {
            List<IGingerWebElement> Elements = new List<IGingerWebElement>(); 

           foreach (IWebElement element in  DriverService.Driver.FindElements(By.ClassName(ClassName)))
            {
                Elements.Add(new GingerWebElement(element));
            }

            return Elements;
        }

        public List<IGingerWebElement> LocateElementsbyCSS(string Css)
        {
            List<IGingerWebElement> Elements = new List<IGingerWebElement>();

            foreach (IWebElement element in DriverService.Driver.FindElements(By.CssSelector(Css)))
            {
                Elements.Add(new GingerWebElement(element));
            }

            return Elements;
        }

        public List<IGingerWebElement> LocateElementsByTagName(string tag)
        {
            List<IGingerWebElement> Elements = new List<IGingerWebElement>();

            foreach (IWebElement element in DriverService.Driver.FindElements(By.TagName(tag)))
            {
                Elements.Add(new GingerWebElement(element));
            }

            return Elements;
        }

    }
}
