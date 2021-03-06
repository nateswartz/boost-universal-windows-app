﻿using BluetoothController.Commands.Abstract;

namespace BluetoothController.Commands.Basic
{
    public class HubVoltageNotificationsCommand : PortInputFormatSetupSingleCommandType
    {
        public HubVoltageNotificationsCommand(bool enabled)
        {
            var portID = "3C"; // Voltage
            var mode = "00";
            var interval = "05000000"; // Delta Interval
            var notificationEnabled = enabled ? "01" : "00"; // Enabled
            HexCommand = AddHeader($"{portID}{mode}{interval}{notificationEnabled}");
        }
    }
}


