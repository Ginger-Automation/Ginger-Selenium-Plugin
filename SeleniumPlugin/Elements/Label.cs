using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    public class Label : GingerWebElement, ILabel
    {
        public string GetFont()
        {
            return WebElement.GetAttribute("font");


        }

        public string GetText()
        {
            return WebElement.Text;
        }

        public string Getvalue()
        {
            string Value = WebElement.Text;

            if(string.IsNullOrEmpty(Value))
            {
                Value = WebElement.GetAttribute("value");
            }
            return Value;
        }
    }
}
