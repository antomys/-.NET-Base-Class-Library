using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Windows;
using System.Windows.Navigation;
using StockAnalyzer.Core.Models;

namespace StockAnalyzer.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var watch = new Stopwatch();
            watch.Start();
            StockProgress.Visibility = Visibility.Visible;
            StockProgress.IsIndeterminate = true;

            var client = new WebClient();

            var content = client.DownloadString($"http://localhost:61363/api/stocks/{Ticker.Text}");

            var data = JsonSerializer.Deserialize<IEnumerable<StockPrice>>(content);

            Stocks.ItemsSource = data;
            
            StocksStatus.Text = $"Loaded stocks for {Ticker.Text} in {watch.ElapsedMilliseconds}ms";
            StockProgress.Visibility = Visibility.Hidden;
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));

            e.Handled = true;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}