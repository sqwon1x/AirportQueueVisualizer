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

namespace AirportQueueVisualizer.Pages
{
    public partial class QueuePage : Page
    {
        public QueuePage(string terminalName)
        {
            InitializeComponent();
            TerminalTitleLabel.Text = $"Керування чергою: {terminalName}";
        }
    }
}
