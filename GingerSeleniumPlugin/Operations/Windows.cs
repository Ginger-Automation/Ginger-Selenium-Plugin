using Amdocs.Ginger.Plugin.Core;
using Amdocs.Ginger.Plugin.Core.ActionsLib;
using GingerSeleniumPlugin.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using static Amdocs.Ginger.Plugin.Core.ActionsLib.ActInfo;

namespace GingerSeleniumPlugin.Operations
{
    public class Windows
    {

        public static void HandleWindows(IWebDriver Driver, GingerAction GA, ActBrowserInfo act,string DefaultWindowHandler)
        {

            switch (act.ControlAction)
            {
                case eControlAction.Maximize:
                    Driver.Manage().Window.Maximize();
                    break;
                case eControlAction.Close:
                    Driver.Close();
                    break;
                case eControlAction.SwitchToDefaultFrame:
                    Driver.SwitchTo().DefaultContent();
                    break;
                case eControlAction.SwitchFrame:
                    HandleSwitchFrame(Driver, GA, act);
                    break;
                case eControlAction.CloseAll:
                    Driver.Quit();
                    break;

                case eControlAction.Refresh:
                    Driver.Navigate().Refresh();
                    break;
                case eControlAction.SwitchWindow:
                    SwitchWindow(Driver,GA,act);
                    break;
                case eControlAction.SwitchToParentFrame:
                    Driver.SwitchTo().ParentFrame();
                    break;

                case eControlAction.GetWindowTitle:
                    string title = Driver.Title;
                    if (!string.IsNullOrEmpty(title))
                        GA.AddOutput("Actual", title);
                    else
                        GA.AddOutput("Actual", "");
                    break;
                case eControlAction.SwitchToDefaultWindow:
                    Driver.SwitchTo().Window(DefaultWindowHandler);
                    break;
                case eControlAction.GetPageSource:
                    GA.AddOutput("PageSource", Driver.PageSource);
                    break;
                case eControlAction.GetPageURL:
                    GA.AddOutput("PageURL", Driver.Url);
                    Uri url = new Uri(Driver.Url);
                    GA.AddOutput("Host", url.Host);
                    GA.AddOutput("Path", url.LocalPath);
                    GA.AddOutput("PathWithQuery", url.PathAndQuery);
                    break;
                case eControlAction.CheckPageLoaded:
                    WaitTillPageLoaded(Driver);
                    break;
                case eControlAction.CloseTabExcept:
                    CloseAllTabsExceptOne(Driver,GA,act);
                    break;
            }
        }

        private static void HandleSwitchFrame(IWebDriver Driver, GingerAction GA, ActBrowserInfo act)
        {

            IWebElement e = null;
            try
            {
                if (act.LocateValue != "" && act.LocateValue != null)
                {
                    e = LocateElement.LocateElementByLocator(Driver, act.LocateBy, act.LocateValue);
                    if (e != null)
                    {
                        Driver.SwitchTo().Frame(e);
                        return;
                    }
                    else
                    {
                        GA.AddError("Error: Unable to find the specified frame");
                        return;
                    }
                }
                else if (!string.IsNullOrEmpty(act.Value))
                {
                    if (act.Value != "DEFAULT")
                    {
                        Driver.SwitchTo().Frame(act.Value);
                        return;
                    }
                    else
                    {
                        Driver.SwitchTo().DefaultContent();
                        return;
                    }
                }
                else if ((act.Value == "" || act.Value == null) && (act.LocateValue == "" || act.LocateValue == null))
                {
                    GA.AddError("Locate Value or Value is Empty");
                    return;
                }
            }
            catch
            {
                GA.AddError("Error: Unable to find the specified frame");
                return;
            }
        }

        private static void SwitchWindow(IWebDriver Driver, GingerAction GA, ActBrowserInfo act)
        {
            bool BFound = false;
            Stopwatch St = new Stopwatch();
            string searchedWinTitle = GetSearchedWinTitle(GA,act);
            // retry mechanims for 20 seconds waiting for the window to open, 500ms intervals                  

            St.Reset();

            int waitTime = 60;
            
             //TODO: get wait time from GingerRunner 

            while (St.ElapsedMilliseconds < waitTime * 1000)
            {
                {
                    St.Start();
                    try
                    {
                        ReadOnlyCollection<string> openWindows = Driver.WindowHandles;
                        foreach (String winHandle in openWindows)
                        {
                            if (act.LocateBy == eLocateBy.ByTitle)
                            {

                                string winTitle = Driver.SwitchTo().Window(winHandle).Title;
                                // We search windows titles based on contains
                                //TODO: maybe contains is better +  need exact match or other 
                                if (winTitle.IndexOf(searchedWinTitle, StringComparison.CurrentCultureIgnoreCase) >= 0)
                                {
                                    // window found put some info in ExInfo
                                    GA.AddExInfo(winTitle);
                                    BFound = true;
                                    break;
                                }
                            }
                            if (act.LocateBy == eLocateBy.ByUrl)
                            {
                                string winurl = Driver.SwitchTo().Window(winHandle).Url;
                                // We search windows titles based on contains
                                //TODO: maybe contains is better +  need exact match or other 
                                if (winurl.IndexOf(searchedWinTitle, StringComparison.CurrentCultureIgnoreCase) >= 0)
                                {
                                    // window found put some info in ExInfo
                                    GA.AddExInfo(winurl);
                                    BFound = true;
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    { break; }
                    if (BFound) return;
                    Thread.Sleep(500);
                }
            }
            if (BFound)
                return;//window found
            else
            {
                // Added below code to verify if there is any window exist with blank title - 
                // It has been added to handle special scenario where window is not having title in IE but have in Chrome
                ReadOnlyCollection<string> openWindows = Driver.WindowHandles;
                foreach (String winHandle in openWindows)
                {
                    //    if (winHandle == currentWindow)
                    //        continue;
                    string winTitle = Driver.SwitchTo().Window(winHandle).Title;

                    if (String.IsNullOrEmpty(winTitle))
                    {
                        GA.AddExInfo("Switched to window having Empty Title.");
                        BFound = true;
                        return;
                    }
                }
                //Window not found
                // switch back to previous window
                //if (currentWindow != "Error")
                //    Driver.SwitchTo().Window(currentWindow);
                GA.AddError( "Error: Window with the title '" + searchedWinTitle + "' was not found.");

            }
        }


  
        public static string GetSearchedWinTitle(GingerAction GA,ActBrowserInfo act)
        {
            string searchedWinTitle = string.Empty;

            if (String.IsNullOrEmpty(act.Value) && String.IsNullOrEmpty(act.LocateValue))
            {
            throw new InvalidOperationException( "Error: The window title to search for is missing.");
            
            }
            else
            {
                if (String.IsNullOrEmpty(act.LocateValue) == false)
                    searchedWinTitle = act.LocateValue;
                else
                    searchedWinTitle = act.Value;
            }
            return searchedWinTitle;
        }
        public static void  WaitTillPageLoaded(IWebDriver Driver)
        {
            //TODO: slow function, try to check alternatives or let the user config wait for
            try
            {
                bool DomElementIncreasing = true;
                int CurrentDomElementSize = 0;
                int SameSizzeCounter = 0;
                while (DomElementIncreasing)
                {
                    Thread.Sleep(300);

                    int instanceSize = Driver.FindElements(By.CssSelector("*")).Count;

                    if (instanceSize > CurrentDomElementSize)
                    {
                        CurrentDomElementSize = instanceSize;
                        SameSizzeCounter = 0;
                        continue;
                    }
                    else
                    {
                        SameSizzeCounter++;
                        if (SameSizzeCounter == 5)
                        {
                            DomElementIncreasing = false;
                        }
                    }
                }
            }
            catch
            {
                // Do nothing...
            }
        }


        public static void CloseAllTabsExceptOne(IWebDriver Driver,GingerAction GA, ActBrowserInfo act)
        {
            string originalHandle = string.Empty;
            string searchedWinTitle = GetSearchedWinTitle(GA,act);
            ReadOnlyCollection<string> openWindows = Driver.WindowHandles;
            foreach (String winHandle in openWindows)
            {
                if (act.LocateBy == eLocateBy.ByTitle)
                {
                    string winTitle = Driver.SwitchTo().Window(winHandle).Title;
                    if (winTitle.IndexOf(searchedWinTitle, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        originalHandle = Driver.CurrentWindowHandle;
                        GA.AddExInfo( winTitle);
                        continue;
                    }
                    else
                    {
                        Driver.Close();
                    }
                }
                if (act.LocateBy == eLocateBy.ByUrl)
                {
                    string winurl = Driver.SwitchTo().Window(winHandle).Url;
                    if (winurl.IndexOf(searchedWinTitle, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        originalHandle = Driver.CurrentWindowHandle;
                        GA.AddExInfo( winurl);
                        continue;
                    }
                    else
                    {
                        Driver.Close();
                    }
                }
            }

            Driver.SwitchTo().Window(originalHandle);
        }
    }
}
