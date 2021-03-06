﻿using BluetoothController.Commands.Abstract;

namespace BluetoothController.Commands.Basic
{
    public class HubTypeCommand : DeviceInfoCommandType
    {
        public HubTypeCommand()
        {
            var infoType = "0B"; // Device Type
            var action = "05"; // One-time request
            HexCommand = AddHeader($"{infoType}{action}00");
        }
    }
}


