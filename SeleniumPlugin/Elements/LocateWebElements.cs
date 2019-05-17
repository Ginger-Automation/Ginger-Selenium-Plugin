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
        IGingerWebElement ILocateWebElement.LocateElementByID(eElementType elementType, string id)
        {
            IWebElement element = mDriver.FindElement(By.Id(id));
            return wrapper(elementType, element);
        }

        // By Xpath
        IGingerWebElement ILocateWebElement.LocateElementByXPath(eElementType elementType, string xpath)
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


        public IGingerWebElement LocateElementByCss(eElementType elementType, string LocateValue) 
        {
            // find using selenium                                  
            IWebElement element = mDriver.FindElement(By.CssSelector(LocateValue));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem

            return wrapper(elementType, element);
        }

        public IGingerWebElement LocateElementByLinkTest(eElementType elementType, string LocateValue) 
        {
            IWebElement element = mDriver.FindElement(By.LinkText(LocateValue));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem
            return wrapper(elementType, element);

        }

        public IGingerWebElement LocateElementByPartiallinkText(eElementType elementType, string LocateValue) 
        {
            IWebElement element = mDriver.FindElement(By.PartialLinkText(LocateValue));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem

            return wrapper(elementType, element);
        }

        public IGingerWebElement LocateElementByTag(eElementType elementType, string LocateValue) 
        {

            IWebElement element = mDriver.FindElement(By.TagName(LocateValue));

            // TODO: ??? !!!!
            string tagName = element.TagName;
            // Based on tag name check if correct elem

            // Create Ginger wrapper object which is subclass of GingerWebElement
            return wrapper(elementType, element);
        }

        
      

        private IGingerWebElement wrapper(eElementType elementType, IWebElement element)
        {
            IGingerWebElement Element= null;
            switch(elementType)
            {
                case eElementType.Button:  // return the generic base element
                    Element= new Button();
                    break;
                case eElementType.Canvas:
                    // TODO: think if we want to check TagName to verify element type
                    Element= new Canvas();
                    break;
                case eElementType.CheckBox:
                    Element= new Button();
                    break;
                case eElementType.ComboBox:
                    Element = new ComboBox();
                    break;
                case eElementType.Div:
                    Element = new GingerWebElement();
                    break;
                case eElementType.Image:
                    Element = new GingerWebElement();
                    break;
                case eElementType.Label:
                    Element = new Label();
                    break;
                case eElementType.List:
                    Element = new List();
                    break;
                case eElementType.RadioButton:
                    Element = new RadioButton();
                    break;
                case eElementType.Span:
                    Element = new Span();
                    break;
                case eElementType.Table:
                    Element = new Table();
                    break;
                case eElementType.TextBox:
                    Element = new TextBox();
                    break;
                case eElementType.WebElement:
                case eElementType.Unknown:
                    Element = new GingerWebElement();
                    break;
                case eElementType.HyperLink:
                    Element = new HyperLink();
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
