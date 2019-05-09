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


        public IGingerWebElement LocateElementByCss(ElementType elementType, string LocateValue) 
        {
            // find using selenium                                  
            IWebElement element = mDriver.FindElement(By.CssSelector(LocateValue));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem

            return wrapper(elementType, element);
        }

        public IGingerWebElement LocateElementByLinkTest(ElementType elementType, string LocateValue) 
        {
            IWebElement element = mDriver.FindElement(By.LinkText(LocateValue));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem
            return wrapper(elementType, element);

        }

        public IGingerWebElement LocateElementByPartiallinkText(ElementType elementType, string LocateValue) 
        {
            IWebElement element = mDriver.FindElement(By.PartialLinkText(LocateValue));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem

            return wrapper(elementType, element);
        }

        public IGingerWebElement LocateElementByTag(ElementType elementType, string LocateValue) 
        {

            IWebElement element = mDriver.FindElement(By.TagName(LocateValue));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem

            // Create Ginger wrapper object which is subclass of GingerWebElement
            return wrapper(elementType, element);
        }

        
      

        private IGingerWebElement wrapper(ElementType elementType, IWebElement element)
        {
            IGingerWebElement Element= null;
            switch(elementType)
            {
                case ElementType.Button:  // return the generic base element
                    Element= new Button();
                    break;
                case ElementType.Canvas:
                    // TODO: think if we want to check TagName to verify element type
                    Element= new Canvas();
                    break;
                case ElementType.CheckBox:
                    Element= new Button();
                    break;
                case ElementType.ComboBox:
                    Element = new ComboBox();
                    break;
                case ElementType.Div:
                    Element = new GingerWebElement();
                    break;
                case ElementType.Image:
                    Element = new GingerWebElement();
                    break;
                case ElementType.Label:
                    Element = new Label();
                    break;
                case ElementType.List:
                    Element = new List();
                    break;
                case ElementType.RadioButton:
                    Element = new RadioButton();
                    break;
                case ElementType.Span:
                    Element = new Span();
                    break;
                case ElementType.Table:
                    Element = new Table();
                    break;
                case ElementType.TextBox:
                    Element = new TextBox();
                    break;
                case ElementType.WebElement:
                    Element = new GingerWebElement();
                    break;
            }

            Element.Element = element;

            if (Element is GingerWebElement GE)
            {
                GE.Driver = mDriver;

            }

            return Element;
        }
    }
}
