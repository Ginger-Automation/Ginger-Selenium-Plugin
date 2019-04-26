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
        public NewPayLoad HandleUIELementAction(IPlatformService service, NewPayLoad ActionPayload)
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

           

            return null;
        }
    }
}
