using System;
using System.Collections.Generic;
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
using AirportQueueVisualizer.Models;

namespace AirportQueueVisualizer.Pages
{
    public partial class QueuePage : Page
    {
        ObservableCollection<Passenger> passengers = new ObservableCollection<Passenger>();

        Passenger editingPassenger = null;

        public QueuePage(string terminalName)
        {
            InitializeComponent();
            TerminalTitleLabel.Text = $"Керування чергою: {terminalName}";
            PassengerList.ItemsSource = passengers;
        }

        private void AddOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(FlightBox.Text))
            {
                MessageBox.Show("Будь ласка, введіть ім'я та рейс!");
                return;
            }

            if (editingPassenger == null)
            {
                passengers.Add(new Passenger { Name = NameBox.Text.Trim(), Flight = FlightBox.Text.Trim() });
            }
            else
            {
                editingPassenger.Name = NameBox.Text.Trim();
                editingPassenger.Flight = FlightBox.Text.Trim();

                editingPassenger = null;
                BtnAddOrUpdate.Content = "Додати";
                BtnCancelEdit.Visibility = Visibility.Collapsed;
                PassengerList.IsEnabled = true;
            }

            NameBox.Clear();
            FlightBox.Clear();
            NameBox.Focus();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (PassengerList.SelectedItem is Passenger selected)
            {
                editingPassenger = selected;

                NameBox.Text = selected.Name;
                FlightBox.Text = selected.Flight;

                BtnAddOrUpdate.Content = "Зберегти";
                BtnCancelEdit.Visibility = Visibility.Visible;
                PassengerList.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Оберіть пасажира для редагування.");
            }
        }

        private void CancelEdit_Click(object sender, RoutedEventArgs e)
        {
            editingPassenger = null;
            NameBox.Clear();
            FlightBox.Clear();

            BtnAddOrUpdate.Content = "Додати";
            BtnCancelEdit.Visibility = Visibility.Collapsed;
            PassengerList.IsEnabled = true;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (PassengerList.SelectedItem is Passenger selected)
            {
                passengers.Remove(selected);
            }
            else
            {
                MessageBox.Show("Оберіть пасажира для видалення.");
            }
        }
    }
}
