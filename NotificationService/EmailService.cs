using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService
{
    internal class EmailService : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Email Service: {message}");
        }
    }
}
