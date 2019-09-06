using Ginger.Plugin.Platform.Web.Elements;
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

        protected static void MultiClick(IWebElement webElement, IWebDriver driver)
        {
            throw new NotImplementedException();
        }

        public GingerWebElement()
        {
            
        }

        public GingerWebElement(IWebElement element)
        {
            WebElement = element;
        }

        public void DragAndDrop(string DragDropType, IGingerWebElement targetElement)
        {


            switch (DragDropType)
            {
                case "DragDropSelenium":
                    OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(Driver);
                    OpenQA.Selenium.Interactions.IAction dragdrop = action.ClickAndHold(this.WebElement).MoveToElement(targetElement.Element as IWebElement).Release(targetElement.Element as IWebElement).Build();
                    dragdrop.Perform();
                    break;
                case "DragDropJS":
                    string script = Resources.Html5DragAndDrop;
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                    executor.ExecuteScript(script, this.WebElement, targetElement);
                    break;
               

            }
        }

        public string GetAttribute(string attributeName)
        {
            return WebElement.GetAttribute(attributeName);
        }

        public int GetHeight()
        {
            return WebElement.Size.Height;
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

        public void SetFocus()
        {
            Hover();
        }


        #region Common StaticClick Functions



       internal static bool Click(IWebElement clickElement)
        {


            clickElement.Click();
            return true;
        }
        internal static void MouseClick(IWebElement clickElement, IWebDriver Driver)
        {
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(Driver);
            action.MoveToElement(clickElement).Click().Build().Perform();
        }
 

        internal static void  DoubleClick(IWebElement clickElement,IWebDriver Driver)
        {
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(Driver);
            action.Click(clickElement).Click(clickElement).Build().Perform();

        }

        internal static void JavascriptClick(IWebElement clickElement, IWebDriver Driver)
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
                catch  (Exception)
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
        public static void SelectElementByValue(IWebElement we, string Text)
        {
            SelectElement se = new SelectElement(we);
            se.SelectByValue(Text);
        }

        public static string GetSelectedValue(IWebElement webElement)
        {
            SelectElement se = new SelectElement(webElement);
            string value=se.SelectedOption.Text;

       
            if (string.IsNullOrEmpty(value))
            {
                value = se.SelectedOption.GetAttribute("value");
            }

            return value;
        }


        #endregion

    }
}
