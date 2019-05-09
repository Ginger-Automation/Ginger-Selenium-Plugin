using Ginger.Plugin.Platform.Web.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    public class TextBox : GingerWebElement, ITextBox   // TODO: remove interface IGingerWebElement after method moved to GingerWebElement
    {
        public TextBox()
        {

        }
        

        public TextBox(IWebElement element) : base(element)
        {
            base.Element = element;
        }


        public void ClearValue()
        {
            WebElement.Clear();
        }

        public string GetFont()
        {
            return WebElement.GetAttribute("font");
        }

        public string GetText()
        {
            string txt = WebElement.GetAttribute("value");
            return txt;
        }

        public int GetTextLength()
        {
            return WebElement.GetAttribute("value").Length;
        }

        public string GetValue()
        {
            string Value = WebElement.GetAttribute("value");
            if (string.IsNullOrEmpty(Value))
            {
                Value = WebElement.Text;
            }
            return Value;
        }

        public bool IsValuePopulated()
        {

            return WebElement.GetAttribute("value").Trim() != "";

        }

        public void SendKeys(string keys)
        {
            this.WebElement.SendKeys(keys);
        }

#warning Pending Implementation
        public void SetMultiValue(string[] values)
        {
           throw new NotImplementedException();        }

        public void SetText(string Text)
        {
            try
            {
                WebElement.Clear();
            }
            finally
            {
                WebElement.SendKeys(Text);
            }
        }

        public void SetValue(string Text)
        {
            try
            {
                WebElement.Clear();
            }
            finally
            {
                WebElement.SendKeys(Text);
            }
        }
    }
}
