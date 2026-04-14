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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> passengers = new ObservableCollection<string>();
        
        public MainWindow()
        {
            InitializeComponent();
            PassengerList.ItemsSource = passengers;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(FlightBox.Text))
            {
                MessageBox.Show("Введіть дані!");
                return;
            }

            passengers.Add($"{NameBox.Text} - рейс {FlightBox.Text}");

            NameBox.Clear();
            FlightBox.Clear();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (PassengerList.SelectedItem != null)
            {
                passengers.Remove(PassengerList.SelectedItem.ToString());
            }
        }
    }
}