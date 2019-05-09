using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    class HyperLink : GingerWebElement, IHyperLink
    {
        public void Click()
        {
            GingerWebElement.Click(this.WebElement);
        }

        public void ClickandValidate()
        {
            throw new NotImplementedException();
        }

        public void DoubleClick()
        {
            GingerWebElement.DoubleClick(this.WebElement, this.Driver);
          
        }

        public string GetValue()
        {
            return WebElement.GetAttribute("href");
                 
           
        }

        public void JavascriptClick()
        {
            GingerWebElement.JavascriptClick(this.WebElement, this.Driver);
        }

        public void MultiClick()
        {
            throw new NotImplementedException();
        }
    }
}
