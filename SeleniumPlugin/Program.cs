using Amdocs.Ginger.Plugin.Core;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using System;
using System.Collections.Generic;

namespace SeleniumPlugin
{
    class Program
    {

        internal static List<SeleniumServiceBase> DriverSessions = new List<SeleniumServiceBase>();
        static void Main(string[] args)
        {


            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CleanUp);
            Console.Title = "Selenium Plugin";
            Console.WriteLine("Starting Selenium Plugin");

            using (GingerNodeStarter gingerNodeStarter = new GingerNodeStarter())
            {
                if (args.Length > 0)
                {
                    gingerNodeStarter.StartFromConfigFile(args[0]);  // file name 
                }
                else
                {                    
                    gingerNodeStarter.StartNode("Chrome Service 1", new SeleniumChromeService());

                }
                gingerNodeStarter.Listen();
            }

        }

        private static void CleanUp(object sender, EventArgs e)
        {

            foreach(SeleniumServiceBase SB in DriverSessions)
            {

                try
                {
                    SB.Driver.Quit();
                }

                catch
                {

                }
            }
            
        }
    }
}
