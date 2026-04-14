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

namespace AirportQueueVisualizer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new HomePage());
        }
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
        }

        private void BtnQueue_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new QueuePage());
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InfoPage());
        }
    }
}