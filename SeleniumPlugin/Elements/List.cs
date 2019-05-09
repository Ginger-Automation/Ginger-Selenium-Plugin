using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    public class List : GingerWebElement, IWebList
    {

        public void ClearValue()
        {
            GingerWebElement.ClearList(WebElement);
        }

        public List<string> GetValidValue()
        {

            return GingerWebElement.GetDropDownListOptions(WebElement);


        }

        public bool IsValuePopulated()
        {
            return GingerWebElement.CheckValuePopulated(WebElement);


        }

        public void Select(string Value)
        {


            GingerWebElement.CheckValuePopulated(WebElement);
        }

        public void SelectByIndex(int index)
        {
            GingerWebElement.SelecElementByIndex(WebElement, index);
        }

        public void SelectByText(string Text)
        {
            GingerWebElement.SelectElementByText(WebElement, Text);

        }
    }
}
