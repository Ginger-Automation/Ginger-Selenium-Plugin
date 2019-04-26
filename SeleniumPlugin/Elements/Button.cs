using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    public class Button : GingerWebElement, IButton
    {
        public void Click()
        {
            WebElement.Click();
        }

        public string GetValue()
        {
            return WebElement.Text;
        }
    }
}
