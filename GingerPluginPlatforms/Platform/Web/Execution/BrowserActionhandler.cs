using Amdocs.Ginger.CoreNET.RunLib;
using GingerCoreNET.Drivers.CommunicationProtocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugin.Platform.Web.Execution
{
    class BrowserActionhandler
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
      internal  string ExInfo;
        internal List<NodeActionOutputValue> AOVs = new List<NodeActionOutputValue>();


        private Dictionary<string, string> InputParams;
        IBrowserActions BrowserService = null;
        public BrowserActionhandler(IBrowserActions mbrowserActions, Dictionary<string, string> minputParams)
        {

            InputParams = minputParams;
             BrowserService = mbrowserActions;

            ElementAction = (eControlAction)Enum.Parse(typeof(eControlAction), InputParams["ControlAction"]);


        }


      internal  void ExecuteAction()
        {

            switch(ElementAction)
            {

                case eControlAction.GotoURL:
                    Console.WriteLine();
                    string Url = InputParams["Value"];
                    string GotoURLType;

                    InputParams.TryGetValue("GotoURLType", out GotoURLType);
                    if(string.IsNullOrEmpty(GotoURLType))
                    {
                        GotoURLType = "Current";

                    }
                    BrowserService.Navigate(Url, GotoURLType);


                    break;

                case eControlAction.GetPageURL:

          
                    AOVs.Add(new NodeActionOutputValue() { Param = "PageUrl", Value = BrowserService.GetCurrentUrl() });

                    break;
            }

        }

    }
}
