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
using AirportQueueVisualizer.Models;

namespace AirportQueueVisualizer.Pages
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            this.Loaded += HomePage_Loaded;
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            TotalPassengerLabel.Text = AirportData.AllPassengers.Count.ToString();
        }
    }
}
