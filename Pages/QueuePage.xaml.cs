using AirportQueueVisualizer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Runtime.CompilerServices;

namespace AirportQueueVisualizer.Pages
{
    public partial class QueuePage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Passenger> Passengers { get; set; } = new ObservableCollection<Passenger>();

        private Passenger _currentPassenger;
        public Passenger CurrentPassenger
        {
            get => _currentPassenger;
            set { _currentPassenger = value; OnPropertyChanged(); }
        }

        private Passenger _editingPassenger = null;

        public QueuePage()
        {
            InitializeComponent();

            Passengers = AirportData.AllPassengers;
            CurrentPassenger = new Passenger { Name = "", Flight = "" };

            this.DataContext = this;
        }

        private void AddOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentPassenger.Name) || string.IsNullOrWhiteSpace(CurrentPassenger.Flight))
            {
                MessageBox.Show((string)Application.Current.Resources["MsgErrorEmpty"]);
                return;
            }

            if (_editingPassenger == null)
            {
                Passengers.Add(new Passenger
                {
                    Name = CurrentPassenger.Name.Trim(),
                    Flight = CurrentPassenger.Flight.Trim(),
                });
            }
            else
            {
                _editingPassenger.Name = CurrentPassenger.Name.Trim();
                _editingPassenger.Flight = CurrentPassenger.Flight.Trim();

                _editingPassenger = null;
                BtnAddOrUpdate.Content = Application.Current.Resources["BtnAdd"];
                BtnCancelEdit.Visibility = Visibility.Collapsed;
                PassengerList.IsEnabled = true;
            }

            CurrentPassenger.Name = "";
            CurrentPassenger.Flight = "";

            AirportData.SaveData();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (PassengerList.SelectedItem is Passenger selected)
            {
                _editingPassenger = selected;

                CurrentPassenger.Name = selected.Name;
                CurrentPassenger.Flight = selected.Flight;

                BtnAddOrUpdate.Content = Application.Current.Resources["BtnSave"];
                BtnCancelEdit.Visibility = Visibility.Visible;
                PassengerList.IsEnabled = false;
            }
        }

        private void CancelEdit_Click(object sender, RoutedEventArgs e)
        {
            _editingPassenger = null;

            CurrentPassenger.Name = "";
            CurrentPassenger.Flight = "";

            BtnAddOrUpdate.Content = Application.Current.Resources["BtnAdd"];
            BtnCancelEdit.Visibility = Visibility.Collapsed;
            PassengerList.IsEnabled = true;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (PassengerList.SelectedItem is Passenger selected)
            {
                Passengers.Remove(selected);
                AirportData.SaveData();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}