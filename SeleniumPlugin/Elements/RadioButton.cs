using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    public class RadioButton : GingerWebElement, IRadioButton
    {

        public void JavascriptClick()
        {
            GingerWebElement.JavascriptClick(this.WebElement, Driver);
        }
        public void Click()
        {
            WebElement.Click();
        }



        public void DoubleClick()
        {
            GingerWebElement.DoubleClick(this.WebElement, Driver);
        }
        public void MultiClick()
        {
            GingerWebElement.MultiClick(this.WebElement, Driver);
        }

        public void MouseClick()
        {
            GingerWebElement.MouseClick(this.WebElement, Driver);
        }

        public string GetValue()
        {
            string Value = WebElement.Text;
            if (string.IsNullOrEmpty(Value))
            {
                Value = WebElement.GetAttribute("value");
            }


            return Value;
        }
    }
}
