﻿using BluetoothController.Controllers;
using BluetoothController.Hubs;
using BluetoothController.Responses;
using System;
using System.Threading.Tasks;

namespace BluetoothController.EventHandlers
{
    public class SystemTypeUpdateHubTypeEventHandler : IEventHandler
    {
        private readonly HubController _controller;

        public Type HandledEvent { get; } = typeof(SystemType);

        public SystemTypeUpdateHubTypeEventHandler(HubController controller)
        {
            _controller = controller;
        }

        public async Task HandleEventAsync(Response response)
        {
            var data = (SystemType)response;
            SetupHub(data.HubType);
            await Task.CompletedTask;
        }

        private void SetupHub(HubType hubType)
        {
            switch (hubType)
            {
                case HubType.BoostMoveHub:
                    if (_controller.Hub is BoostMoveHub)
                        return;
                    var moveHub = new BoostMoveHub();
                    if (_controller.Hub != null)
                        moveHub.Ports = _controller.Hub.Ports;
                    _controller.Hub = moveHub;
                    break;
                case HubType.TwoPortHandset:
                    if (_controller.Hub is RemoteHub)
                        return;
                    var remoteHub = new RemoteHub();
                    if (_controller.Hub != null)
                        remoteHub.Ports = _controller.Hub.Ports;
                    _controller.Hub = remoteHub;
                    break;
                case HubType.TwoPortHub:
                    if (_controller.Hub is TwoPortHub)
                        return;
                    var twoPortHub = new TwoPortHub();
                    if (_controller.Hub != null)
                        twoPortHub.Ports = _controller.Hub.Ports;
                    _controller.Hub = twoPortHub;
                    break;
            }
        }
    }
}
