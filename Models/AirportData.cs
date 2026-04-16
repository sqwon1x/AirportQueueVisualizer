using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AirportQueueVisualizer.Models;

namespace AirportQueueVisualizer.Models
{
    public static class AirportData
    {
        public static ObservableCollection<Passenger> AllPassengers { get; } = new ObservableCollection<Passenger>();
    }
}
