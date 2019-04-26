using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugin.Platform.Web.Elements
{
    public interface ILocateWebElement
    {

        // IServiceSession  Service { get; set; }
        T LocateElementByCss<T>(string LocateValue) where T : IGingerWebElement, new();

        
        T LocateElementByID<T>(string id) where T : IGingerWebElement, new();

        T LocateElementByLinkTest<T>(string LocateValue) where T : IGingerWebElement, new();

        T LocateElementByPartiallinkText<T>(string LocateValue) where T : IGingerWebElement, new();
        T LocateElementByTag<T>(string LocateValue) where T : IGingerWebElement, new();
        T LocateElementByXPath<T>(string LocateValue) where T : IGingerWebElement, new();

        List<IGingerWebElement> LocateElementsbyCSS(string Css);

        List<IGingerWebElement> LocateElementsByClassName(string ClassName);
        List<IGingerWebElement> LocateElementsByTagName(string tag);
       
    }
}
