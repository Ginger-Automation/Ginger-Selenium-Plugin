using Ginger.Plugin.Platform.Web.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    public class GingerWebElement : IGingerWebElement
    {
        // keep it protected not public
        protected IWebElement WebElement;

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
            throw new NotImplementedException();
        }

        public int GetItemCount()
        {
            throw new NotImplementedException();
        }

        public KeyValuePair<int, int> GetSize()
        {
            throw new NotImplementedException();
        }

        public string GetStyle()
        {
            throw new NotImplementedException();
        }

        public int GetWidth()
        {
            return int.Parse(WebElement.GetAttribute("width"));
        }

        public void Hover()
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled()
        {
            throw new NotImplementedException();
        }

        public bool IsVisible()
        {
            throw new NotImplementedException();
        }

        public void RightClick()
        {
            throw new NotImplementedException();
        }

        public string RunJavascript()
        {
            throw new NotImplementedException();
        }

        public void ScrollToElement()
        {
            throw new NotImplementedException();
        }

        public void SetDiabled()
        {
            throw new NotImplementedException();
        }

        public void SetFocues()
        {
            throw new NotImplementedException();
        }


        public TextBox webTextBox()
        {
            return null;
        }
    }
}
