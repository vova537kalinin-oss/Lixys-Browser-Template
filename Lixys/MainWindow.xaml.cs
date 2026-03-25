using System;
using System.IO;
using System.Windows;
using System.Windows.Input; // Критически важно для MouseButtonEventArgs
using Microsoft.Web.WebView2.Wpf;

namespace lixys
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            // Исправляем ошибку CS8622 через лямбду
            this.StateChanged += (s, e) => MainWindow_StateChanged(s, e);
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await webView.EnsureCoreWebView2Async(null);
            OpenStartPage();
        }

        private void OpenStartPage()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "index.html");
            webView.Source = File.Exists(path) ? new Uri(path) : new Uri("https://www.google.com");
        }

        // Логика перемещения окна
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) MaximizeRestore_Click(sender, e);
            else this.DragMove();
        }

        private void UrlBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string url = UrlBar.Text;
                if (!url.StartsWith("http") && !url.Contains(":\\")) url = "https://" + url;
                try { webView.Source = new Uri(url); } catch { }
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;
        private void Close_Click(object sender, RoutedEventArgs e) => this.Close();

        private void MaximizeRestore_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void MainWindow_StateChanged(object? sender, EventArgs e)
        {
            if (BtnRestore != null)
                BtnRestore.Content = (this.WindowState == WindowState.Maximized) ? "" : "";
        }

        private void Back_Click(object sender, RoutedEventArgs e) { if (webView.CanGoBack) webView.GoBack(); }
        private void Forward_Click(object sender, RoutedEventArgs e) { if (webView.CanGoForward) webView.GoForward(); }
        private void Reload_Click(object sender, RoutedEventArgs e) => webView.Reload();
        private void Home_Click(object sender, RoutedEventArgs e) => OpenStartPage();
    }
}