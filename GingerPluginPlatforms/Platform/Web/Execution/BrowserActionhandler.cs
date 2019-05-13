using Amdocs.Ginger.CoreNET.RunLib;
using GingerCoreNET.Drivers.CommunicationProtocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugin.Platform.Web.Execution
{
    class BrowserActionhandler:IActionHandler
    {
        public enum eControlAction
        {

            InitializeBrowser,

            GetPageSource,

            GetPageURL,

            SwitchFrame,

            SwitchToDefaultFrame,

            SwitchToParentFrame,

            Maximize,

            Close,

            SwitchWindow,

            SwitchToDefaultWindow,

            InjectJS,

            CheckPageLoaded,

            OpenURLNewTab,

            GotoURL,

            CloseTabExcept,

            CloseAll,

            Refresh,

            NavigateBack,

            DismissMessageBox,

            DeleteAllCookies,

            AcceptMessageBox,

            GetWindowTitle,

            GetMessageBoxText,

            SetAlertBoxText,

            RunJavaScript
        }
        eControlAction ElementAction;

        internal List<NodeActionOutputValue> AOVs = new List<NodeActionOutputValue>();
        string Value;

        private Dictionary<string, string> InputParams;
        IBrowserActions BrowserService = null;

        public string ExecutionInfo { get; set; }
        public string Error { get ; set; }

        public BrowserActionhandler(IBrowserActions mbrowserActions, Dictionary<string, string> minputParams)
        {

            InputParams = minputParams;
            BrowserService = mbrowserActions;
            InputParams.TryGetValue("Value", out Value);
            ElementAction = (eControlAction)Enum.Parse(typeof(eControlAction), InputParams["ControlAction"]);


        }


        internal void ExecuteAction()
        {

            try
            {

                switch (ElementAction)
                {

                    case eControlAction.GotoURL:
                        Console.WriteLine();

                        string GotoURLType;

                        InputParams.TryGetValue("GotoURLType", out GotoURLType);

                        if (string.IsNullOrEmpty(GotoURLType))
                        {
                            GotoURLType = "Current";

                        }
                        BrowserService.Navigate(Value, GotoURLType);


                        break;

                    case eControlAction.GetPageURL:


                        AOVs.Add(new NodeActionOutputValue() { Param = "PageUrl", Value = BrowserService.GetCurrentUrl() });

                        break;
                    case eControlAction.Maximize:
                        BrowserService.Maximize();
                        break;
                    case eControlAction.Close:
                        BrowserService.CloseCurrentTab();
                        break;
                    case eControlAction.CloseAll:
                        BrowserService.CloseWindow();
                        break;
                    case eControlAction.Refresh:
                        BrowserService.Refresh();
                        break;
                    case eControlAction.NavigateBack:
                        BrowserService.NavigateBack();
                        break;
                    case eControlAction.DismissMessageBox:
                        BrowserService.DismissMessageBox();
                        break;
                    case eControlAction.DeleteAllCookies:
                        BrowserService.DeleteAllCookies();
                        break;

                    case eControlAction.AcceptMessageBox:

                        BrowserService.AcceptMessageBox();
                        break;
                    case eControlAction.GetWindowTitle:

                        BrowserService.GetTitle();
                        break;
                    case eControlAction.GetMessageBoxText:

                        BrowserService.GetTitle();
                        break;
                    case eControlAction.SetAlertBoxText:

                        BrowserService.SetAlertBoxText(Value);
                        break;
                    case eControlAction.RunJavaScript:

                        object Output = BrowserService.ExecuteScript(Value);
                        if (Output != null)
                        {
                            AOVs.Add(new NodeActionOutputValue() { Param = "Actual", Value = Output.ToString() });
                        }
                        break;
                }
            }


            catch(Exception ex)
            {
                Error = ex.Message;
                ExecutionInfo = ex.StackTrace;
            }
        }

    }
}
