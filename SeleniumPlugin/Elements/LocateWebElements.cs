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
        

     

        public List<IGingerWebElement> LocateElementsByClassName(string ClassName)
        {
            List<IGingerWebElement> Elements = new List<IGingerWebElement>(); 

           foreach (IWebElement element in  mDriver.FindElements(By.ClassName(ClassName)))
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

        public List<IGingerWebElement> LocateElementsbyCSS(string Css)
        {
            List<IGingerWebElement> Elements = new List<IGingerWebElement>();

            foreach (IWebElement element in mDriver.FindElements(By.CssSelector(Css)))
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

        public T LocateElementByCss<T>(string LocateValue) where T : IGingerWebElement, new()
        {
            // find using selenium                                  
            IWebElement element = mDriver.FindElement(By.CssSelector(LocateValue));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem

            // Create Ginger wrapper object which is subclass of GingerWebElement
            T obj = new T();
            obj.Element = element;
            return obj;
        }

        public T LocateElementByLinkTest<T>(string LocateValue) where T : IGingerWebElement, new()
        {
            IWebElement element = mDriver.FindElement(By.LinkText(LocateValue));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem

            // Create Ginger wrapper object which is subclass of GingerWebElement
            T obj = new T();
            obj.Element = element;
            return obj;
        }

        public T LocateElementByPartiallinkText<T>(string LocateValue) where T : IGingerWebElement, new()
        {
            IWebElement element = mDriver.FindElement(By.PartialLinkText(LocateValue));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem

            // Create Ginger wrapper object which is subclass of GingerWebElement
            T obj = new T();
            obj.Element = element;
            return obj;
        }

        public T LocateElementByTag<T>(string LocateValue) where T : IGingerWebElement, new()
        {

            IWebElement element = mDriver.FindElement(By.TagName(LocateValue));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem

            // Create Ginger wrapper object which is subclass of GingerWebElement
            T obj = new T();
            obj.Element = element;
            return obj;
        }

        public T LocateElementByXPath<T>(string LocateValue) where T : IGingerWebElement, new()
        {
            IWebElement element = mDriver.FindElement(By.XPath(LocateValue));

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
