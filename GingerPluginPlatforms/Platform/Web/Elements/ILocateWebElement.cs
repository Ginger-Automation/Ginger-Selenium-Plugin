using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugin.Platform.Web.Elements
{
    public interface ILocateWebElement
    {

        IServiceSession  Service { get; set; }
        IGingerWebElement LocateElementByCSS(string Css);            
        T LocateElementByID<T>(string id) where T : IGingerWebElement, new();

        IGingerWebElement LocateElementByLinkTest(string Linktext);
        IGingerWebElement LocateElementByPartiallinkText(string PartialLinkText);
        IGingerWebElement LocateElementByTag(string Tag);
        IGingerWebElement LocateElementByXPath(string Xpath);

        List<IGingerWebElement> LocateElementsbyCSS(string Css);

        List<IGingerWebElement> LocateElementsByClassName(string ClassName);
        List<IGingerWebElement> LocateElementsByTagName(string tag);

    }
}
