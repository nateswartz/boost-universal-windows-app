﻿using System;

namespace SDKTemplate.Responses
{
    public enum DeviceType
    {
        HubName = 1,
        ButtonState = 2,
        FirmwareVersion = 3,
        LEDState = 23,
        ColorDistanceState = 37,
        ExternalMotorState = 38,
        InternalMotorState = 39
    }

    public class DeviceInfo : Response
    {
        public DeviceType DeviceType { get; set; }

        public DeviceInfo(string body) : base(body)
        {
            DeviceType = (DeviceType)Convert.ToInt32(body.Substring(6, 2), 16);
        }
    }
}