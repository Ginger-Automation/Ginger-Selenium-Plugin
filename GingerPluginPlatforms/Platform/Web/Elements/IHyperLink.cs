﻿using Ginger.Plugin.Platform.Web.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugin.Platform.Web.Elements
{
    public interface IHyperLink: IGingerWebElement,IClick
    {

        string GetValue();


#warning Pending Definations
        //        string MultiClicks();
    }
}
