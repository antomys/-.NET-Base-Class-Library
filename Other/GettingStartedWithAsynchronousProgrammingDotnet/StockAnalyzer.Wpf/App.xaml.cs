using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace StockAnalyzer.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using var client = new HttpClient();
            try
            {
                var _ = await client.GetAsync("http://localhost:7168");
                MessageBox.Show("Connected to 7168!", "Hell yeah!", MessageBoxButton.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Ensure that StockAnalyzer.Web is running, expecting to be running on https://localhost:7168. You can configure the solution to start two projects by right clicking the StockAnalyzer solution in Visual Studio, select properties and then multiple Startup Projects.", "StockAnalyzer.Web IS NOT RUNNING");
            }
        }
    }
}