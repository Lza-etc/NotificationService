﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService
{
    internal class PushNotificationService : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Push Notification Service: {message}");
        }
    }
}
