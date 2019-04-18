using Amdocs.Ginger.Plugin.Core;
using Amdocs.Ginger.Plugin.Core.ActionsLib;
using GingerSeleniumPlugin.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using static Amdocs.Ginger.Plugin.Core.ActionsLib.ActInfo;

namespace GingerSeleniumPlugin.Operations
{
   public class DragNDrop
    {

        public static void DoDragAndDrop(IWebDriver Driver, GingerAction GA, ActUIElementInfo act, IWebElement e)
        {
            var sourceElement = e;

            string TargetElementLocatorValue = act.TargetLocateValue;

            if (act.TargetLocateBy != eLocateBy.ByXY)
            {
                string TargetElementLocator = act.TargetLocateBy.ToString();
                IWebElement targetElement = LocateElement.LocateElementByLocator(Driver, act.TargetLocateBy, TargetElementLocatorValue);
                if (targetElement != null)
                {

                    switch (act.DragDropType)
                    {
                        case eElementDragDropType.DragDropSelenium:
                            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(Driver);
                            OpenQA.Selenium.Interactions.IAction dragdrop = action.ClickAndHold(sourceElement).MoveToElement(targetElement).Release(targetElement).Build();
                            dragdrop.Perform();
                            break;
                        case eElementDragDropType.DragDropJS:
                            string script = Resources.Draganddrop;
                            script += "simulateHTML5DragAndDrop(arguments[0], arguments[1])";
                            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                            executor.ExecuteScript(script, sourceElement, targetElement);
                            break;
                        default:
                            GA.AddError("Failed to perform drag and drop, invalid drag and drop type");
                            break;

                    }
                    //TODO: Add validation to verify if Drag and drop is perfromed or not and fail the action if needed

                }
                else
                {
                    GA.AddError("Target Element not found: " + act.TargetLocateBy.ToString() + "=" + TargetElementLocatorValue);
                }
            }
            else
            {
               
                DoDragandDropByOffSet(Driver,sourceElement, act.XCoordinate, act.YCoordinate);
            }
        }

        private static void DoDragandDropByOffSet(IWebDriver Driver, IWebElement sourceElement, int xLocator, int yLocator)
        {
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(Driver);
            action.DragAndDropToOffset(sourceElement, xLocator, yLocator).Build().Perform();
        }
    }
}
