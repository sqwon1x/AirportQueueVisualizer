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
    public class Passenger
    {
        public string Name { get; set; }
        public string Flight { get; set; }
    }

    public partial class MainWindow : Window
    {
        ObservableCollection<Passenger> passengers = new ObservableCollection<Passenger>();

        public MainWindow()
        {
            InitializeComponent();
            PassengerList.ItemsSource = passengers;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(FlightBox.Text))
            {
                MessageBox.Show("Будь ласка, введіть ім'я та номер рейсу!");
                return;
            }

            passengers.Add(new Passenger
            {
                Name = NameBox.Text.Trim(),
                Flight = FlightBox.Text.Trim(),
            });

            NameBox.Clear();
            FlightBox.Clear();

            NameBox.Focus();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (PassengerList.SelectedItem is Passenger selectedPassenger)
            {
                passengers.Remove(selectedPassenger);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть пасажира зі списку для видалення.");
            }
        }
    }
}