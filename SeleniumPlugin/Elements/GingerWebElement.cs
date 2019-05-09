﻿using Ginger.Plugin.Platform.Web.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    public class GingerWebElement : IGingerWebElement
    {
        // keep it protected not public
        protected IWebElement WebElement;
        public IWebDriver Driver { get; set; }
        // TODO: remove the public accessor
        public object Element
        {
            get
            {
                return WebElement;
            }
            set
            {
                WebElement = value as IWebElement;
            }
        }

        public GingerWebElement()
        {
            
        }

        public GingerWebElement(IWebElement element)
        {
            WebElement = element;
        }
#warning Drag n Drop Pending implementation
        public void DragAndDrop()
        {
           throw new NotImplementedException();
        }

        public string GetAttribute(string attributeName)
        {
            return WebElement.GetAttribute(attributeName);
        }

        public int GetHeight()
        {
            return WebElement.Size.Height;
        }
#warning pending Implementation 
        public int GetItemCount()
        {
           throw new NotImplementedException();
        }

        public Size GetSize()
        {
            return WebElement.Size;
        }

        public string GetStyle()
        {
            return WebElement.GetAttribute("style");
        }

        public int GetWidth()
        {
            return WebElement.Size.Width;
        }

        public void Hover()
        {
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(Driver);
            action.MoveToElement(WebElement).Build().Perform();
        }

        public bool IsEnabled()
        {
            return WebElement.Enabled;
        }

        public bool IsVisible()
        {
            return WebElement.Displayed;
        }

        public void RightClick()
        {
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(Driver);
            action.ContextClick(WebElement).Build().Perform();
        }

        public string RunJavascript(string script)
        {
            return ((IJavaScriptExecutor)Driver).ExecuteScript(script).ToString();
        }

        public void ScrollToElement()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", WebElement);
        }
#warning pending Implementation 
        public void SetDiabled()
        {
           throw new NotImplementedException();
        }

        public void SetFocus()
        {
            Hover();
        }


        #region Common StaticClick Functions



        static bool  ClickandValidate(IWebElement clickElement)
        {
            return false;


        }

        static void  DoubleClick(IWebElement clickElement,IWebDriver Driver)
        {
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(Driver);
            action.Click(clickElement).Click(clickElement).Build().Perform();

        }

        static void JavascriptClick(IWebElement clickElement, IWebDriver Driver)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("return arguments[0].click()", clickElement);

        }

        #endregion



        #region Common CLombobox/List functions 

        public static List<string> GetDropDownListOptions(IWebElement e)
        {

            List<string> Options = new List<string>();
            // there is better way to get the options
            ReadOnlyCollection<IWebElement> elems = e.FindElements(By.TagName("option"));
            string s = "";
            foreach (IWebElement e1 in elems)
            {
                Options.Add(e1.Text);
            }

            return Options;
        }
        public static void ClearList(IWebElement e)
        {
            e.Clear();
        }

   
        public static bool CheckValuePopulated(IWebElement e)
        {
            SelectElement seIsPrepopulated = new SelectElement(e);

            return (seIsPrepopulated.SelectedOption.ToString().Trim() != "");
        }

        public void SelectElement(IWebElement we, string Value)
        {
            SelectElement se = new SelectElement(we);
            if (WebElement != null)
            {
                se = null;
                try
                {
                    se = new SelectElement(WebElement);
                    se.SelectByText(Value);
                }
                catch (Exception ex)
                {

                    se.SelectByValue(Value);
                }

            }
        }

        public static void SelecElementByIndex(IWebElement we,int index)
        {
            SelectElement se = new SelectElement(we);
            se.SelectByIndex(index);
        }

        public static void SelectElementByText(IWebElement we,string Text)
        {
            SelectElement se = new SelectElement(we);
            se.SelectByText(Text);
        }




        #endregion

    }
}
