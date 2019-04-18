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
    public class Click
    {

        public static void DoUIElementClick(IWebElement clickElement,eElementAction clickType,IWebDriver Driver)
        {
            switch (clickType)
            {
                case eElementAction.Click:
                    clickElement.Click();
                    break;

                case eElementAction.JavaScriptClick:
                    ((IJavaScriptExecutor)Driver).ExecuteScript("return arguments[0].click()", clickElement);
                    break;

                case eElementAction.MouseClick:
                    OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(Driver);
                    action.MoveToElement(clickElement).Click().Build().Perform();
                    break;
                case eElementAction.AsyncClick:
                    try
                    {
                        ((IJavaScriptExecutor)Driver).ExecuteScript("var el=arguments[0]; setTimeout(function() { el.click(); }, 100);", clickElement);
                    }
                    catch (Exception)
                    {
                        clickElement.Click();
                    }
                    break;

                case eElementAction.DoubleClick:
                    OpenQA.Selenium.Interactions.Actions actionDoubleClick = new OpenQA.Selenium.Interactions.Actions(Driver);
                    actionDoubleClick.Click(clickElement).Click(clickElement).Build().Perform();
                    break;

                case eElementAction.MouseRightClick:
                    OpenQA.Selenium.Interactions.Actions actionMouseRightClick = new OpenQA.Selenium.Interactions.Actions(Driver);
                    actionMouseRightClick.ContextClick(clickElement).Build().Perform();
                    break;

                default:
                    throw new NotSupportedException("The Click is not supported by this plugin "+ clickType.ToString());

            }
        }


        public static bool ClickAndValidteHandler(IWebElement clickElement, eElementAction clickType, IWebDriver Driver,ActUIElementInfo act,GingerAction GA)
        {
           

          

           


            //Loop through clicks flag check:
       
            //Do click:
            DoUIElementClick(clickElement,act.ClickType, Driver);
            //check if validation element exists
            IWebElement elmToValidate = LocateElement.LocateElementByLocator(Driver, act.ValidationElementLocateby,act.ValidationElementLocatorValue);

            if (elmToValidate != null)
                return true;
            else
            {
                if (act.LoopThroughClicks)
                {
                    //TODO: Implement Loop Through Clicks
                    /*
                    Platforms.PlatformsInfo.WebPlatform webPlatform = new Platforms.PlatformsInfo.WebPlatform();
                    List<ActUIElement.eElementAction> clicks = webPlatform.GetPlatformUIClickTypeList();

                    ActUIElement.eElementAction executedClick = clickType;
                    foreach (ActUIElement.eElementAction singleclick in clicks)
                    {
                        if (singleclick != executedClick)
                        {
                            DoUIElementClick((ActUIElement.eElementAction)singleclick, clickElement);
                            elmToValidate = LocateElement(act, true, validationElementLocateby.ToString(), validationElementLocatorValue);
                            if (elmToValidate != null)
                            {
                                return true;
                            }
                        }
                    }
                */}
            }
            GA.AddError( "Error:  Validation Element not found - " + act.ValidationElementLocateby + " Using Value : " + act.ValidationElementLocatorValue);
            return false;
        }

 
    }
}
