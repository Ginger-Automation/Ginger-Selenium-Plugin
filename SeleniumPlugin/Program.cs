using Amdocs.Ginger.Plugin.Core;
using Ginger.Plugins.Web.SeleniumPlugin.Services;
using System;

namespace SeleniumPlugin
{
    class Program
    {
        static void Main(string[] args)
        {
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
                    // gingerNodeStarter.StartNode("String Service", new StringService());
                    // gingerNodeStarter.StartNode("Math Service A", new MathService(), "10.122.112.124", 15001);
                    //gingerNodeStarter.StartNode("Math Service A", new MathService());
                    //gingerNodeStarter.StartNode("Math Service B", new MathService());
                    //gingerNodeStarter.StartNode("Math Service C", new MathService());

                    // gingerNodeStarter.StartNode("String Service", new StringService(), "172.30.80.1", 15001);
                    gingerNodeStarter.StartNode("Chrome Service 1", new SeleniumChromeService());

                    // file content options
                    // i.e.:
                    // Math 1 | PluginExample1.MathService
                    // Math 1 | PluginExample1.MathService | 10.122.112.124 | 15001
                    // Math 2 | PluginExample1.MathService | 10.122.112.124 | 15001
                    // gingerNodeStarter.StartFromConfigFile(@"C:\temp\GingerNodeStarter\SeleneniumChromeFF.txt");
                }
                gingerNodeStarter.Listen();
            }
        }
    }
}
