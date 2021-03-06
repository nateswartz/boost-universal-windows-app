﻿using BluetoothController.Commands.Abstract;

namespace BluetoothController.Commands.Basic
{
    public class HubFirmwareCommand : DeviceInfoCommandType
    {
        public HubFirmwareCommand()
        {
            var infoType = "03"; // Firmware
            var action = "05"; // One-time request
            HexCommand = AddHeader($"{infoType}{action}00");
        }
    }
}


