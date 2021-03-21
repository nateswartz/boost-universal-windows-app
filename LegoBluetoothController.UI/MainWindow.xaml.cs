﻿using BluetoothController;
using BluetoothController.Controllers;
using BluetoothController.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace LegoBluetoothController.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static IBluetoothLowEnergyAdapter _adapter;

        static List<IHubController> _controllers = new List<IHubController>();

        public MainWindow()
        {
            _adapter = new BluetoothLowEnergyAdapter(HandleDiscover, HandleConnect, HandleNotification);
            InitializeComponent();
        }

        private void DiscoverButton_Click(object sender, RoutedEventArgs e)
        {
            LogMessage("Searching for devices...");
            _adapter.StartBleDeviceWatcher();
        }

        private async Task HandleNotification(IHubController controller, string message)
        {
            LogMessage($"{controller.HubType}: {message}");
            await Task.CompletedTask;
        }

        private async Task HandleDiscover(DiscoveredDevice device)
        {
            LogMessage($"Discovered device: {device.Name}");
            await Task.CompletedTask;
        }

        private async Task HandleConnect(IHubController controller, string errorMessage)
        {
            if (controller != null)
            {
                _controllers.Add(controller);

                LogMessage($"Connected device: {Enum.GetName(typeof(HubType), controller.HubType)}");

                await Task.CompletedTask;
            }
            else
            {
                LogMessage($"Failed to connect: {errorMessage}");
            }
        }

        private void LogMessage(string message)
        {
            LogMessages.Text += message + Environment.NewLine;
        }
    }
}
