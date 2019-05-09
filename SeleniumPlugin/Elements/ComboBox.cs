using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    class ComboBox : GingerWebElement, IComboBox
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
