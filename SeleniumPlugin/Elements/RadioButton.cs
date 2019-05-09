﻿using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    class RadioButton : GingerWebElement, IRadioButton
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
