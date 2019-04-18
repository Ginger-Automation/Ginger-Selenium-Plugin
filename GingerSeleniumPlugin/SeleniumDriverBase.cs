using Amdocs.Ginger.Plugin.Core;
using Amdocs.Ginger.Plugin.Core.ActionsLib;
using Amdocs.Ginger.Plugin.Core.Drivers;
using GingerSeleniumPlugin.Operations;
using GingerSeleniumPlugin.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using static Amdocs.Ginger.Plugin.Core.ActionsLib.ActInfo;

namespace GingerSeleniumPlugin
{
    public abstract class SeleniumDriverBase : IServiceSession, IUIElementAction, IWebPlatform
    {
    
        public IWebDriver webDriver;
        public string DefaultWindowHandler;
        public void StartSession()
        {
          this.StartDriver();
            DefaultWindowHandler = webDriver.CurrentWindowHandle;
        }

        public abstract void StartDriver();
        public virtual void StopDriver()
        {
            this.webDriver.Quit();

        }


        public abstract string GetDriverFilePath();


        public void StopSession()
        {
            StopDriver();
        }

        public void PerformUIElementAction(GingerAction GA, ActUIElementInfo act)
        {
            IWebElement webElement = LocateElement.LocateElementByLocator(webDriver, act.LocateBy, act.LocateValue);



            switch (act.ElementAction)
            {

                case eElementAction.Click:
                case eElementAction.JavaScriptClick:
                case eElementAction.DoubleClick:
                case eElementAction.MouseRightClick:
                case eElementAction.MultiClicks:
                    Click.DoUIElementClick(webElement, act.ElementAction, webDriver);
                    break;
                case eElementAction.ClickAndValidate:
                    Click.ClickAndValidteHandler(webElement, act.ElementAction, webDriver,act,GA);
                    break;

                case eElementAction.DragDrop:
                    DragNDrop.DoDragAndDrop(webDriver,GA, act, webElement);
                    break;


            }

        }

        public void HandleBrowserElementAction(GingerAction GA, ActBrowserInfo act)
        {
            switch (act.ControlAction)
            {
                case eControlAction.SwitchToDefaultFrame:
                case eControlAction.SwitchFrame:
                case eControlAction.Close:
                case eControlAction.Maximize:
                case eControlAction.CloseAll:
                case eControlAction.SwitchWindow:
                case eControlAction.Refresh:
                case eControlAction.SwitchToParentFrame:
                case eControlAction.SwitchToDefaultWindow:
                case eControlAction.GetWindowTitle:
                case eControlAction.CloseTabExcept:
                case eControlAction.CheckPageLoaded:
                case eControlAction.GetPageURL:
                case eControlAction.GetPageSource:
                    Windows.HandleWindows(this.webDriver,GA, act,this.DefaultWindowHandler);
                    break;

                case eControlAction.OpenURLNewTab:
                case eControlAction.GotoURL:
                case eControlAction.DeleteAllCookies:
                case eControlAction.RunJavaScript:
                case eControlAction.InjectJS:
                case eControlAction.NavigateBack:
                case eControlAction.AcceptMessageBox:
                case eControlAction.DismissMessageBox:
                case eControlAction.GetMessageBoxText:
                case eControlAction.SetAlertBoxText:
            



                    Browser.HandleBrowserAction(this.webDriver, GA, act);

                    break;
         

                case eControlAction.InitializeBrowser:
                    this.StartDriver();
                    break;

    

                default:
                    throw new Exception("Action unknown/Not Impl in Driver - " + this.GetType().ToString());
            }
        }

       
    }
}
