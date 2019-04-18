using Amdocs.Ginger.Plugin.Core;
using System;

namespace GingerSeleniumPlugin
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Starting Ginger Selenium Plugin");

            using (GingerNodeStarter gingerNodeStarter = new GingerNodeStarter())
            {
                if (args.Length > 0)
                {
                    gingerNodeStarter.StartFromConfigFile(args[0]);
                }
                else
                {
                  //  gingerNodeStarter.StartNode("Selenium Chrome 1", new SeleniumChromeDriver());
                }
                gingerNodeStarter.Listen();
            }
        }
    }
}
