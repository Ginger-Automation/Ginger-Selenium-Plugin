using Ginger.Plugin.Platform.Web.Elements;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    class Span : GingerWebElement, ISpan
    {
        public string GetValue()
        {
            string Value = WebElement.Text;
            if (string.IsNullOrEmpty(Value))
            {
                Value = WebElement.GetAttribute("value");
            }


            return Value;
        }
        public void SetValue(string Text)
        {


            WebElement.Clear();
            WebElement.SendKeys(Text);
        }
    }
}
