﻿using LegoBoostController.Models;

namespace LegoBoostController.Responses
{
    public class ResponseProcessor
    {
        const string TILT_SENSOR_PORT = "3a";
        const string VOLTAGE_SENSOR_PORT = "3c";

        public Response CreateResponse(string notification, PortState portState)
        {
            var response = new Response(notification);
            switch (response.MessageType)
            {
                case MessageType.DeviceInfo:
                    var deviceInfo = new DeviceInfo(notification);
                    switch (deviceInfo.DeviceType)
                    {
                        case DeviceType.HubName:
                            return new HubName(notification);
                        case DeviceType.ButtonState:
                            return new ButtonStateMessage(notification);
                        case DeviceType.FirmwareVersion:
                            return new FirmwareVersion(notification);
                    }
                    return deviceInfo;
                case MessageType.PortInfo:
                    var portInfo = new PortInfo(notification);
                    switch (portInfo.DeviceType)
                    {
                        case DeviceType.LEDState:
                            return new LEDState(notification);
                        case DeviceType.ColorDistanceState:
                            portState.CurrentColorDistanceSensorPort = portInfo.Port;
                            return new ColorDistanceState(notification);
                        case DeviceType.ExternalMotorState:
                            portState.CurrentExternalMotorPort = portInfo.Port;
                            return new ExternalMotorState(notification);
                        case DeviceType.InternalMotorState:
                            return new InternalMotorState(notification);
                    }
                    return portInfo;
                case MessageType.Error:
                    return new Error(notification);
                case MessageType.SensorData:
                    var sensorData = new SensorData(notification);
                    if (sensorData.Port == portState.CurrentColorDistanceSensorPort)
                    {
                        return new ColorDistanceData(notification);
                    }
                    if (sensorData.Port == portState.CurrentExternalMotorPort)
                    {
                        var externalMotorData = new ExternalMotorData(notification);
                        switch (externalMotorData.DataType)
                        {
                            case MotorDataType.Angle:
                                return new AngleData(notification);
                            case MotorDataType.Speed:
                                return new SpeedData(notification);
                        }
                        return new ExternalMotorData(notification);
                    }
                    if (sensorData.Port == TILT_SENSOR_PORT)
                    {
                        return new TiltData(notification);
                    }
                    if (sensorData.Port == VOLTAGE_SENSOR_PORT)
                    {
                        return new VoltageData(notification);
                    }
                    return sensorData;
            }
            return response;
        }
    }
}
