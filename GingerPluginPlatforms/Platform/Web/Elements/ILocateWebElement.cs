using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugin.Platform.Web.Elements
{
    public enum ElementType
    {
        WebElement,  // unknown or generic 
        TextBox,
        Button,
        Div,
        H1,
        Link
            // ....
    }

    public interface ILocateWebElement
    {
        // IGingerWebElement LocateElementByID<T>(string id) where T : IGingerWebElement;
        IGingerWebElement LocateElementByID(ElementType elementType, string id);

        IGingerWebElement LocateElementByXPath(ElementType elementType, string xpath);

        // IServiceSession  Service { get; set; }
        T LocateElementByCss<T>(string LocateValue) where T : IGingerWebElement, new();


        // T LocateElementByID<T>(string id) where T : IGingerWebElement, new();

        

        T LocateElementByLinkTest<T>(string LocateValue) where T : IGingerWebElement, new();

        T LocateElementByPartiallinkText<T>(string LocateValue) where T : IGingerWebElement, new();
        T LocateElementByTag<T>(string LocateValue) where T : IGingerWebElement, new();
        

        List<IGingerWebElement> LocateElementsbyCSS(string Css);

        List<IGingerWebElement> LocateElementsByClassName(string ClassName);
        List<IGingerWebElement> LocateElementsByTagName(string tag);
       
    }
}
