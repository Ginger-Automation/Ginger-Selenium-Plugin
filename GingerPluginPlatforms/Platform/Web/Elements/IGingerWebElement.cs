using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugin.Platform.Web.Elements
{
    //TODO: move to GingerWebElement base class and make abstract
   public interface IGingerWebElement
    {
        object Element { get; set; }
        void DragAndDrop();
        string GetAttribute(string attributeName);
        int GetHeight();
        int GetItemCount();
        KeyValuePair<int, int> GetSize();
        string GetStyle();
        int GetWidth();
        void Hover();
        bool IsEnabled();
        bool IsVisible();
        void RightClick();
        string RunJavascript();
        void ScrollToElement();
        void SetDiabled();
        void SetFocues();
     

    }
}
