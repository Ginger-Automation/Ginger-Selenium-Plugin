﻿using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    class HyperLink : GingerWebElement, IHyperLink
    {
        public string GetValue()
        {
            return WebElement.GetAttribute("href");
                 
           
        }
    }
}