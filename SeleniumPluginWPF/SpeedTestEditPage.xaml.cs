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

using GingerPlugInsNET.PlugInsLib;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SeleniumPluginWPF
{
    /// <summary>
    /// Interaction logic for SpeedTestEditPage.xaml
    /// </summary>
        // We need to use the same ID as we used on the action
    [GingerAction("SpeedTest" , "Speed Test")]
    public partial class SpeedTestEditPage : Page
    {
        public SpeedTestEditPage()
        {
            InitializeComponent();

            List<string> list = new List<string>();
            list.Add("Slow");
            list.Add("Fast");
            list.Add("Super Fast");
            SpeedComboBox.ItemsSource = list;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string url = URLTextBox.Text;
            MessageBox.Show("Hello world 4 - " + url);
        }
    }
}
