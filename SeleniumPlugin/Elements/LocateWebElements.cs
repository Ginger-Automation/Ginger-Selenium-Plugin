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
        
        public LocateWebElements(IWebDriver driver)
        {
            mDriver = driver;
        }

        // by ID
        IGingerWebElement ILocateWebElement.LocateElementByID(ElementType elementType, string id)
        {
            IWebElement element = mDriver.FindElement(By.Id(id));
            return wrapper(elementType, element);
        }

        // By Xpath
        IGingerWebElement ILocateWebElement.LocateElementByXPath(ElementType elementType, string xpath)
        {
            IWebElement element = mDriver.FindElement(By.XPath(xpath));
            return wrapper(elementType, element);
        }


        // TODO: fix all locators below like above

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

        
      

        private IGingerWebElement wrapper(ElementType elementType, IWebElement element)
        {
            switch(elementType)
            {
                case ElementType.WebElement:  // return the generic base element
                    return new GingerWebElement() { Element = element };
                case ElementType.TextBox:
                    // TODO: think if we want to check TagName to verify element type
                    return new TextBox() { Element = element };
                case ElementType.Button:
                    return new Button() { Element = element };
                    // TODO: all the rest
                default:
                    return null;  // Throw
            }
           
        }
    }
}
