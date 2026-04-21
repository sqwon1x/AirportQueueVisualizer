using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Linq;
using AirportQueueVisualizer.Pages;
using AirportQueueVisualizer.Models;

namespace AirportQueueVisualizer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AirportData.LoadData();
            MainFrame.Navigate(new HomePage());
        }
        private void GoToHome(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new HomePage());
        }

        private void GoToQueue(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new QueuePage());
        }

        private void GoToInfo(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new InfoPage());
        }

        private bool isUkrainian = true;

        private void ChangeLanguage_Click(object sender, RoutedEventArgs e)
        {
            isUkrainian = !isUkrainian;
            string dictPath = isUkrainian ? "Resources/LangUA.xaml" : "Resources/LangEN.xaml";

            var oldDict = System.Windows.Application.Current.Resources.MergedDictionaries
                                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Lang"));

            if (oldDict != null)
            {
                System.Windows.Application.Current.Resources.MergedDictionaries.Remove(oldDict);
            }

            var newDict = new ResourceDictionary { Source = new Uri(dictPath, UriKind.Relative) };
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(newDict);
        }

        private bool isDarkTheme = false;

        private void ToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            string themePath = isDarkTheme ? "Resources/DarkTheme.xaml" : "Resources/LightTheme.xaml";

            var oldTheme = System.Windows.Application.Current.Resources.MergedDictionaries
                                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Theme"));

            if (oldTheme != null)
            {
                System.Windows.Application.Current.Resources.MergedDictionaries.Remove(oldTheme);
            }

            var newTheme = new ResourceDictionary { Source = new Uri(themePath, UriKind.Relative) };
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }
    }
}