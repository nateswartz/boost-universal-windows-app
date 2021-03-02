﻿using BluetoothController.Commands.Abstract;
using BluetoothController.Models;

namespace BluetoothController.Commands.Basic
{
    public class PortInfoModeCommand : CommandType
    {
        public PortInfoModeCommand(string portId, string mode, ModeInfoType type) : base(MessageTypes.PortModeInformationRequest)
        {
            HexCommand = AddHeader($"{portId}{mode}{(int)type:X2}");
        }
    }
}


