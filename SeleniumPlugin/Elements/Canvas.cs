using Ginger.Plugin.Platform.Web.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugins.Web.SeleniumPlugin.Elements
{
    class Canvas : GingerWebElement, ICanvas
    {
        public void ClickXY(int x, int y)
        {
            OpenQA.Selenium.Interactions.Actions actionClick = new OpenQA.Selenium.Interactions.Actions(Driver);
            actionClick.MoveToElement(this.WebElement, x, y).Click().Build().Perform();
        }



        public void DrawObject()
        {
            OpenQA.Selenium.Interactions.Actions actionBuilder = new OpenQA.Selenium.Interactions.Actions(Driver);
            Random rnd = new Random();

            OpenQA.Selenium.Interactions.IAction drawAction = actionBuilder.MoveToElement(WebElement, rnd.Next(WebElement.Size.Width / 98, WebElement.Size.Width / 90), rnd.Next(WebElement.Size.Height / 4, WebElement.Size.Height / 3))
                               .Click()
                               .ClickAndHold(WebElement)
                               .MoveByOffset(rnd.Next(WebElement.Size.Width / 95, WebElement.Size.Width / 75), -rnd.Next(WebElement.Size.Height / 6, WebElement.Size.Height / 3))
                               .MoveByOffset(-rnd.Next(WebElement.Size.Width / 30, WebElement.Size.Width / 15), rnd.Next(WebElement.Size.Height / 12, WebElement.Size.Height / 8))
                               .MoveByOffset(rnd.Next(WebElement.Size.Width / 95, WebElement.Size.Width / 80), rnd.Next(WebElement.Size.Height / 12, WebElement.Size.Height / 8))
                               .MoveByOffset(rnd.Next(WebElement.Size.Width / 30, WebElement.Size.Width / 10), -rnd.Next(WebElement.Size.Height / 12, WebElement.Size.Height / 8))
                               .MoveByOffset(-rnd.Next(WebElement.Size.Width / 95, WebElement.Size.Width / 65), rnd.Next(WebElement.Size.Height / 6, WebElement.Size.Height / 3))
                               .Release(WebElement)
                               .Build();
            drawAction.Perform();
        }
    }
}
