#region License
/*
Copyright © 2014-2018 European Support Limited

Licensed under the Apache License, Version 2.0 (the "License")
you may not use this file except in compliance with the License.
You may obtain a copy of the License at 

http://www.apache.org/licenses/LICENSE-2.0 

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS, 
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
See the License for the specific language governing permissions and 
limitations under the License. 
*/
#endregion

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumPluginTest
{
    [TestClass]
    public class GingerNodeTest
    {

       // GingerNode mGingerNode;

        [TestInitialize]
        public void TestInitialize()
        {
            // Start Ginger Node with Selenium driver
            //SeleniumDriver d = new SeleniumDriver();

            //// TODO: check how to externalize  // make it NodeInfo and drivers capabilities
            //DriverCapabilities DC = new DriverCapabilities();
            //DC.OS = "Windows";
            //DC.Platform = "Web";

            //mGingerNode = new GingerNode(DC, d);
            //mGingerNode.StartGingerNode(7700, "127.0.0.1", 7800);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
           // mGingerNode.CloseDriver();
        }



      // Move me to GingerNode Test !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

       
       
    }
}
