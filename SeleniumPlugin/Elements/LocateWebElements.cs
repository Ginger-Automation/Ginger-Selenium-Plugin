using Amdocs.Ginger.Plugin.Core;
using Ginger.Plugin.Platform.Web.Elements;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    public class LocateWebElements : ILocateWebElement
    {
        IWebDriver mDriver;
        // SeleniumServiceBase DriverService { get; set; }
        public LocateWebElements(IWebDriver driver)
        {
            mDriver = driver;
        }

        //public IServiceSession Service
        //{
        //    get
        //    {
        //        return DriverService;
        //    }

        //    set
        //    {

        //        DriverService = value as SeleniumServiceBase;
        //    }
        //}
        

        public IGingerWebElement LocateElementByCSS(string Css)
        {
          IWebElement element=  mDriver.FindElement(By.CssSelector(Css));

            return new GingerWebElement(element);
        }


        public IGingerWebElement LocateElementByID(string ID)
        {
            IWebElement element = mDriver.FindElement(By.Id(ID));

            return new GingerWebElement(element);
        }

        public IGingerWebElement LocateElementByLinkTest(string Linktext)
        {
            IWebElement element = mDriver.FindElement(By.LinkText(Linktext));

            return new GingerWebElement(element);
        }

        public IGingerWebElement LocateElementByPartiallinkText(string PartialLinkText)
        {
            IWebElement element = mDriver.FindElement(By.PartialLinkText(PartialLinkText));

            return new GingerWebElement(element);
        }

        public IGingerWebElement LocateElementByTag(string Tag)
        {
            IWebElement element = mDriver.FindElement(By.TagName(Tag));

            return new GingerWebElement(element);
        }

        public IGingerWebElement LocateElementByXPath(string Xpath)
        {
            IWebElement element = mDriver.FindElement(By.XPath(Xpath));

            return new GingerWebElement(element);
        }

        public List<IGingerWebElement> LocateElementsByClassName(string ClassName)
        {
            List<IGingerWebElement> Elements = new List<IGingerWebElement>(); 

           foreach (IWebElement element in  mDriver.FindElements(By.ClassName(ClassName)))
            {
                Elements.Add(new GingerWebElement(element));
            }

            return Elements;
        }

        public List<IGingerWebElement> LocateElementsbyCSS(string Css)
        {
            List<IGingerWebElement> Elements = new List<IGingerWebElement>();

            foreach (IWebElement element in mDriver.FindElements(By.CssSelector(Css)))
            {
                Elements.Add(new GingerWebElement(element));
            }

            return Elements;
        }

        public List<IGingerWebElement> LocateElementsByTagName(string tag)
        {
            List<IGingerWebElement> Elements = new List<IGingerWebElement>();

            foreach (IWebElement element in mDriver.FindElements(By.TagName(tag)))
            {
                Elements.Add(new GingerWebElement(element));
            }

            return Elements;
        }

        

        public T LocateElementByID<T>(string id) where T : IGingerWebElement, new()
        {
            // find using selenium                                  
            IWebElement element = mDriver.FindElement(By.Id(id));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem

            // Create Ginger wrapper object which is subclass of GingerWebElement
            T obj = new T();
            obj.Element = element;            
            return obj;
        }
    }
}
