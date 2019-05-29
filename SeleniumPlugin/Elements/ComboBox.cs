using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    public class ComboBox : GingerWebElement, IComboBox
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
        public void SetValue(string Value)
        {
            SelectElement combobox = new SelectElement(this.WebElement);
          
            combobox.SelectByText(Value);
            
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
