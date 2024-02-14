using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService
{
    internal class SMSService: INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"SMS Service: {message}");
        }
    }
}
