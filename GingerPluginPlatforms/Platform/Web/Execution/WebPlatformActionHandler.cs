﻿using Amdocs.Ginger.CoreNET.RunLib;
using Amdocs.Ginger.Plugin.Core.ActionsLib;
using Ginger.Plugin.Platform.Web.Elements;
using GingerCoreNET.Drivers.CommunicationProtocol;
using GingerCoreNET.DriversLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Ginger.Plugin.Platform.Web.Execution
{
    public class WebPlatformActionHandler : IPlatformActionHandler
    {
        public NewPayLoad HandleRunAction(IPlatformService service, NewPayLoad ActionPayload)
        {
            string actionType = ActionPayload.GetValueString();

            // TODO: split to class and functions, or we use smart reflection to redirect the action

            if (actionType == "IWebPlatform")
            {                
                string actionInterface = ActionPayload.GetValueString();  // Interface
                string actionfield = ActionPayload.GetValueString();      // Field

                if (actionInterface == "BrowserActions" && actionfield == nameof(IBrowserActions.Navigate))
                {
                    string url = ActionPayload.GetValueString();
                    string error = null;
                    IWebPlatform PlatformService = (IWebPlatform)service;
                    Console.WriteLine("Naviagte to: " + url);
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    try
                    {
                        PlatformService.BrowserActions.Navigate(url);
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    stopwatch.Stop();
                    string exInfo = "Elapsed = " + stopwatch.Elapsed;
                    // Example of how to add output values, in this case we show the url naviagted to
                    List<NodeActionOutputValue> AOVs = new List<NodeActionOutputValue>();
                    AOVs.Add(new NodeActionOutputValue() { Param = "URL", Value = url });
                    NewPayLoad PLRC = CreateActionResult(exInfo, error, AOVs);
                    return PLRC;
                }
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


                    Dictionary<string, string> InputParams = new Dictionary<string, string>();
                    List<NewPayLoad> FieldsandParams =    ActionPayload.GetListPayLoad();


                    foreach (NewPayLoad Np in FieldsandParams)
                    {
                        string Name = Np.GetValueString();

                        string Value = Np.GetValueString();
                        if (!InputParams.ContainsKey(Name))
                        {
                            InputParams.Add(Name, Value);
                        }
                    }
                    UIELementActionHandler Handler = new UIELementActionHandler(PlatformService,InputParams);

                    Handler.ExecuteAction();

                    NewPayLoad PLRC = CreateActionResult(exInfo: "", error: null, Handler.AOVs);
                    return PLRC;
                    /*
                    string LocateBy = ActionPayload.GetValueString();
                    string value = ActionPayload.GetValueString();
                    string ElementType = ActionPayload.GetValueString();
                    string ElementAction = ActionPayload.GetValueString();


              

                    if (ElementType == "TextBox" && ElementAction == nameof(ITextBox.SetText))
                    {
                        string newValue = ActionPayload.GetValueString();
                        ITextBox textbox = (ITextBox)PlatformService.LocatLWebElement.LocateElementByID(Elements.ElementType.TextBox, value);
                        textbox.SetText(newValue);
                        string exInfo = "Set text box value to: " + newValue;                        
                        NewPayLoad PLRC = CreateActionResult(exInfo, "error", null);  // null means no output values
                        return PLRC;
                    }

                    if (ElementType == "TextBox" && ElementAction == nameof(ITextBox.GetText))
                    {                        
                        ITextBox textbox = (ITextBox)PlatformService.LocatLWebElement.LocateElementByID(Elements.ElementType.TextBox, value);
                        string txt = textbox.GetText();
                        string exInfo = "Text box contains - " + txt;
                        List<NodeActionOutputValue> AOVs = new List<NodeActionOutputValue>();
                        AOVs.Add(new NodeActionOutputValue() { Param = "Value", Value = txt });  
                        NewPayLoad PLRC = CreateActionResult( exInfo: exInfo, error: null, outputValues: AOVs);  
                        return PLRC;
                    }
                        */
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




        private NewPayLoad CreateActionResult(string exInfo, string error, List<NodeActionOutputValue> outputValues)
        {
            return GingerNode.CreateActionResult(exInfo, error, outputValues);
            
        }
    }
}