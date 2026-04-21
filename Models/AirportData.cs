using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AirportQueueVisualizer.Models;
using System.IO;
using System.Text.Json;
using Windows;
using System.Windows;

namespace AirportQueueVisualizer.Models
{
    public static class AirportData
    {
        private static readonly string FilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "passengers.json");

        public static ObservableCollection<Passenger> AllPassengers { get; } = new ObservableCollection<Passenger>();

        public static void SaveData()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(AllPassengers, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, jsonString);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Помилка збереження даних: {ex.Message}");
            }
        }

        public static void LoadData()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string jsonString = File.ReadAllText(FilePath);
                    var loadedData = JsonSerializer.Deserialize<ObservableCollection<Passenger>>(jsonString);

                    if (loadedData != null)
                    {
                        AllPassengers.Clear();
                        foreach (var passenger in loadedData)
                        {
                            AllPassengers.Add(passenger);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних: {ex.Message}");
            }
        }
    }
}