using AddressBook.HubConfig;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    public class NotificationService
    {
        private readonly IHubContext<NotificationHub> _hub;

        public NotificationService(IHubContext<NotificationHub> hub)
        {
            _hub = hub;
        }

        public void SendNotificationAsync(string message)
        {
            _hub.Clients.All.SendAsync("NotifyUsers", message);
        }
    }
}
