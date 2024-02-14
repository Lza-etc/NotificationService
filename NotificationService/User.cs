using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get;set;}
        public string Email { get; set; }
        public string Contact { get; set; }
        static int lastUser = 1;
        public User() {
            this.Id=lastUser++;
        }
    }
}
