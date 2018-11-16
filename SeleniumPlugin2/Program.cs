using Amdocs.Ginger.Plugin.Core;
using Amdocs.Ginger.SeleniumPlugin;
using System;

namespace SeleniumPlugin2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ginger Selenium Plugin";

            // Not working on Linux
            // Console.BufferHeight = 100;

            Console.WriteLine("Starting Ginger Selenium Plugin");

            using (GingerNodeStarter gingerNodeStarter = new GingerNodeStarter())
            {
                gingerNodeStarter.StartNode("Selenium Chrome 1" , new SeleniumChromeDriver());
                gingerNodeStarter.Wait();
            }
             // , "192.168.1.117", 150001
                // GingerNodeStarter.StartNode(new MyDriver(), "MyDriver Service 1", "10.122.112.124",15001);
                //GingerNodeStarter.StartNode(new SeleniumChromeDriver(), "Selenium Chrome 1", "192.168.1.117", 150001);

            //GingerNodeStarter.StartNode(new SeleniumChromeDriver(), "Selenium Chrome 2");
            //GingerNodeStarter.StartNode(new SeleniumChromeDriver(), "Selenium Chrome 3");

            //GingerNodeStarter.StartNode(new SeleniumFireFoxDriver(), "Selenium FF 1");
            //GingerNodeStarter.StartNode(new SeleniumFireFoxDriver(), "Selenium FF 2");
            //GingerNodeStarter.StartNode(new SeleniumFireFoxDriver(), "Selenium FF 3");

           // Console.ReadKey();
        }
    }
}
