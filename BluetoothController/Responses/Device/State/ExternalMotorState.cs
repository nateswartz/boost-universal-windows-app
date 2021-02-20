﻿namespace BluetoothController.Responses.Device.State
{
    public class ExternalMotorState : PortState
    {
        public ExternalMotorState(string body) : base(body)
        {
            NotificationType = GetType().Name;
        }

        public override string ToString()
        {
            return $"External Motor {StateChangeEvent} on port {PortLetter}({Port}) [{Body}]";
        }
    }
}