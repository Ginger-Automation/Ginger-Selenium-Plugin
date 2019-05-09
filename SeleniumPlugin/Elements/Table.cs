using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    class Table : GingerWebElement, ITable
    {
        public string GetValue()
        {
            string Value = WebElement.Text;
            if(string.IsNullOrEmpty(Value))
            {
                Value= WebElement.GetAttribute("value");
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
