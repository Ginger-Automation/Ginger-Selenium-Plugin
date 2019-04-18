using Amdocs.Ginger.Plugin.Core;
using Amdocs.Ginger.Plugin.Core.ActionsLib;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using static Amdocs.Ginger.Plugin.Core.ActionsLib.ActInfo;

namespace GingerSeleniumPlugin.Operations
{
    public class Browser
    {

        public static void HandleBrowserAction(IWebDriver Driver, GingerAction GA, ActBrowserInfo act)
        {

            switch (act.ControlAction)
            {
                case eControlAction.OpenURLNewTab:
                    OpenNewTab(Driver);
                    GotoURL(Driver, GA, act);
                    break;

                case  eControlAction.GotoURL:
                    HandleGoToURL(Driver, GA, act);

                    break;
                case eControlAction.DeleteAllCookies:
                    Driver.Manage().Cookies.DeleteAllCookies();
                    break;
                case eControlAction.RunJavaScript:
                    RunJavaScript(Driver, GA, act.Value);
                    break;
                case eControlAction.NavigateBack:
                    Driver.Navigate().Back();
                    break;
                case eControlAction.AcceptMessageBox:
                    try
                    {
                        Driver.SwitchTo().Alert().Accept();
                    }
                    catch (Exception e)
                    {
                        GA.AddError("Error when Accepting MessageBox - ");
                        GA.AddExInfo(e.Message);
                      
                    }
                    break;
                case eControlAction.DismissMessageBox:
                    try
                    {
                        Driver.SwitchTo().Alert().Dismiss();
                    }
                    catch (Exception e)
                    {
                        GA.AddError("Error when Dismissing MessageBox - ");
                        GA.AddExInfo(e.Message);

                    }
                    break;
                case eControlAction.GetMessageBoxText:
                    try
                    {
                        string AlertBoxText = Driver.SwitchTo().Alert().Text;
                        GA.AddOutput("Actual", AlertBoxText);
                       
                    }
                    catch (Exception e)
                    {
                        GA.AddError("Error to Get Text Message Box - ");
                        GA.AddExInfo(e.Message);
                        return;
                    }
                    break;

                case eControlAction.SetAlertBoxText:
                    try
                    {
                        Driver.SwitchTo().Alert().SendKeys(act.Value);

                    }
                    catch (Exception e)
                    {
                        GA.AddError("Error to Get  Alert Box ");
                        GA.AddExInfo(e.Message);
                        return;
                    }
                    break;
                default:
                    throw new NotSupportedException("The Action " + act.ControlAction.ToString() + " is not implemented on current plugin");
            }
        }

        private static void RunJavaScript(IWebDriver driver, GingerAction GA, string script)
        {
            
            try
            {
                object a = null;
                if (!script.ToUpper().StartsWith("RETURN"))
                {
                    script = "return " + script;
                }
                a = ((IJavaScriptExecutor)driver).ExecuteScript(script);
                if (a != null)
                    GA.AddOutput("Actual", a.ToString());
            }
            catch (Exception ex)
            {
                GA.AddError("Error: Failed to run the JavaScript: '" + script + "', Error: '" + ex.Message + "'");
            }
        }

       
        private static void HandleGoToURL(IWebDriver Driver, GingerAction GA, ActBrowserInfo act)
        {
            if (act.GotoURLType == eGotoURLType.NewTab)
            {
                OpenNewTab(Driver);
            }
            else if (act.GotoURLType == eGotoURLType.NewWindow)
            {
                IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Driver;
                javaScriptExecutor.ExecuteScript("newwindow=window.open('about:blank','newWindow','height=250,width=350');if (window.focus) { newwindow.focus()}return false; ");
                Driver.SwitchTo().Window(Driver.WindowHandles[Driver.WindowHandles.Count - 1]);
                Driver.Manage().Window.Maximize();
            }
            GotoURL(Driver,GA,act);

            //TODO: Handle Pom
            /*
            if ((act.GetInputParamValue(ActBrowserElement.Fields.URLSrc) == ActBrowserElement.eURLSrc.UrlPOM.ToString()))
            {
                string POMGuid = act.GetInputParamCalculatedValue(ActBrowserElement.Fields.PomGUID);
                string POMUrl = "";
                if (!string.IsNullOrEmpty(POMGuid))
                {
                    ApplicationPOMModel SelectedPOM = WorkSpace.Instance.SolutionRepository.GetAllRepositoryItems<ApplicationPOMModel>().Where(p => p.Guid.ToString() == POMGuid).FirstOrDefault();
                    POMUrl = SelectedPOM?.PageURL;
                }
                GotoURL(act, POMUrl);
            }
            else
            {
                GotoURL(act, act.GetInputParamCalculatedValue("Value"));
            }*/
        }

        public static void OpenNewTab(IWebDriver Driver)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Driver;
            javaScriptExecutor.ExecuteScript("window.open();");
            Driver.SwitchTo().Window(Driver.WindowHandles[Driver.WindowHandles.Count - 1]);
        }

        private static void GotoURL(IWebDriver Driver,GingerAction GA ,ActBrowserInfo act)
        {
            string sURL = act.Value;

            if (sURL.ToLower().StartsWith("www"))
            {
                sURL = "http://" + sURL;
            }

            Uri uri = ValidateURL(sURL);
            if (uri != null)
            {
                Driver.Navigate().GoToUrl(uri.AbsoluteUri);
            }
            else
            {
                GA.AddError( "Error: Invalid URL. Give valid URL(Complete URL)");
            }
            string winTitle = Driver.Title;

            //TODO: handle IE Certificate Errors
            //if (Driver.GetType() == typeof(InternetExplorerDriver) && winTitle.IndexOf("Certificate Error", StringComparison.CurrentCultureIgnoreCase) >= 0)
            //{
            //    Thread.Sleep(100);
            //    try
            //    {
            //        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            //        Driver.Navigate().GoToUrl("javascript:document.getElementById('overridelink').click()");
            //    }
            //    catch { }
            //    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((int)ImplicitWait);
            //}

            //just to be sure the page is fully loaded
            Windows.WaitTillPageLoaded(Driver);
        }
        public static Uri ValidateURL(String sURL)
        {
            Uri myurl;
            if (Uri.TryCreate(sURL, UriKind.Absolute, out myurl))
            {
                return myurl;
            }
            return null;
        }
    }
}
