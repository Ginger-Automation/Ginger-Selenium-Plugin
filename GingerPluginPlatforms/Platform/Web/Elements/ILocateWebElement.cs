using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugin.Platform.Web.Elements
{
    public enum ElementType
    {
        WebElement,
        Button,
        Canvas,
        CheckBox,
        ComboBox,
        Div,
        Image,
        Label,
        List,
        RadioButton,
        Span,
        Table,
        TextBox
    }

    public interface ILocateWebElement
    {        
        IGingerWebElement LocateElementByID(ElementType elementType, string id);

        IGingerWebElement LocateElementByXPath(ElementType elementType, string xpath);
     

        // TODO: make all below same like above
       IGingerWebElement LocateElementByCss(ElementType elementType, string LocateValue);

       IGingerWebElement LocateElementByLinkTest(ElementType elementType,string LocateValue);

       IGingerWebElement LocateElementByPartiallinkText(ElementType elementType,string LocateValue);
       IGingerWebElement LocateElementByTag(ElementType elementType,string LocateValue);
     /*   
        List<IGingerWebElement> LocateElementsbyCSS(string Css);

        List<IGingerWebElement> LocateElementsByClassName(string ClassName);
        List<IGingerWebElement> LocateElementsByTagName(string tag);
       */
    }
}
