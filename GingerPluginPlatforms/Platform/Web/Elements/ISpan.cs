﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugin.Platform.Web.Elements
{
    public interface ISpan:IGingerWebElement
    {
        void SetValue(string Text);
    }
}