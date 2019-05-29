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

        public string GetValue()
        {

            OpenQA.Selenium.Support.UI.SelectElement seIsPrepopulated = new OpenQA.Selenium.Support.UI.SelectElement(WebElement);
            string Value;
            if (seIsPrepopulated.SelectedOption.ToString().Trim() != "")
            {
                Value = seIsPrepopulated.SelectedOption.GetAttribute("value"); ;
            }
            else
            {
                Value = WebElement.Text;
            }
            if (string.IsNullOrEmpty(Value))
            {
                Value = WebElement.GetAttribute("value");
            }


            return Value;
        }

        public bool IsValuePopulated()
        {
            return GingerWebElement.CheckValuePopulated(WebElement);


        }

        public void Select(string Value)
        {


            GingerWebElement.SelectElementByValue(WebElement, Value);
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
