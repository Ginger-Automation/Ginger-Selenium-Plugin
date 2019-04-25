using Ginger.Plugin.Platform.Web.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    public class WebTextBox : GingerWebElement, IGingerWebElement, ITextBox
    { 
        public WebTextBox(IWebElement element):base(element)
        {
            base.Element = element;
        }

      
        public void ClearValue()
        {
            throw new NotImplementedException();
        }

        public string GetFont()
        {
            throw new NotImplementedException();
        }

        public string GetText()
        {
            throw new NotImplementedException();
        }

        public int GetTextLength()
        {
            throw new NotImplementedException();
        }

        public string GetValue()
        {
            throw new NotImplementedException();
        }

        public bool IsValuePopulated()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string keys)
        {
            throw new NotImplementedException();
        }

        public void SetMultiValue(string[] values)
        {
            throw new NotImplementedException();
        }

        public void SetText(string Text)
        {
            WebElement.SendKeys(Text);
        }

        public void SetValue()
        {
            throw new NotImplementedException();
        }
    }
}
