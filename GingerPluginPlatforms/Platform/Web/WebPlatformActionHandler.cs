using Amdocs.Ginger.Plugin.Core.ActionsLib;
using Ginger.Plugin.Platform.Web.Elements;
using GingerCoreNET.Drivers.CommunicationProtocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ginger.Plugin.Platform.Web
{
    public class WebPlatformActionHandler : IPlatformActionHandler
    {
        public NewPayLoad HandleRunAction(IPlatformService service, NewPayLoad ActionPayload)
        {
            string actionType = ActionPayload.GetValueString();

            if (actionType == "IWebPlatform")
            {
                string s1 = ActionPayload.GetValueString();
                string s2 = ActionPayload.GetValueString();
                string s3 = ActionPayload.GetValueString();
                // string s4 = ActionPayload.GetValueString();
                // TODO: get the Interface, field, method from the pl.... !!!!!!!!!!!
                IWebPlatform PlatformService = (IWebPlatform)service;
                Console.WriteLine("Naviagte to: " + s3);
                PlatformService.BrowserActions.Navigate(s3);
                // mService.GetType().GetInterface.  
                // object o = service.GetType().GetProperty("BrowserActions").GetValue(service); //  .GetInterface("IWebPlatform").
                // o.GetType().GetMethod("Navigate").Invoke(o, new object[] { "http://www.facebook.com" });

                // We send back only item which can change - ExInfo and Output values
                NewPayLoad PLRC = new NewPayLoad("ActionResult");   //TODO: use const
                PLRC.AddValue("ExInfo !!!");  // !!!!!!!!!!!!!!!!!!
                PLRC.AddValue("Errors !!!"); // !!!!!!!!!!!!!!!!!!
                                             // PLRC.AddListPayLoad(GetOutpuValuesPayLoad(nodeGingerAction.Output.OutputValues)); !!!!!!!!!!!!!!!!!!!!!! output value
                PLRC.ClosePackage();
                return PLRC;
            }

            if (actionType == "UIElementAction")
            {
                try
                {
                    IWebPlatform PlatformService = null;
                    if (service is IWebPlatform Mservice)
                    {
                        PlatformService = Mservice;

                    }

                    string LocateBy = ActionPayload.GetValueString();
                    string value = ActionPayload.GetValueString();
                    string ElementType = ActionPayload.GetValueString();
                    string ElementAction = ActionPayload.GetValueString();


                    ITextBox textbox = (ITextBox)PlatformService.LocatLWebElement.LocateElementByID(Elements.ElementType.TextBox, value);
                    textbox.SetText("aaa");

                    NewPayLoad PLRC = new NewPayLoad("ActionResult");   //TODO: use const
                    PLRC.AddValue("ExInfo !!!");  // !!!!!!!!!!!!!!!!!!
                    PLRC.AddValue("Errors !!!"); // !!!!!!!!!!!!!!!!!!
                                                 // PLRC.AddListPayLoad(GetOutpuValuesPayLoad(nodeGingerAction.Output.OutputValues)); !!!!!!!!!!!!!!!!!!!!!! output value
                    PLRC.ClosePackage();
                    return PLRC;
                    
                }
                catch (Exception ex)
                {
                    NewPayLoad newPayLoad = NewPayLoad.Error(ex.Message);
                    return newPayLoad;
                }
            }

            

            NewPayLoad err = NewPayLoad.Error("RunPlatformAction: Unknown action type: " + actionType);
            return err;


            
        }
    }
}
