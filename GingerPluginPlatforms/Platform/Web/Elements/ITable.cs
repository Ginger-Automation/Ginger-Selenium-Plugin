﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugin.Platform.Web.Elements
{
    public interface ITable:IGingerWebElement
    {

        string GetValue();

        void SetValue(string Text);
    }
}
