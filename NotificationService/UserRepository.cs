using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService
{
    internal class UserRepository
    {
        private readonly List<User> users;

        public UserRepository()
        {
            users = new List<User>();
        }

        public void Add(User user)
        {
            users.Add(user);
        }

        public User GetById(int id)
        {
            return users.Find(u => u.Id == id)!;
        }

        public List<User> GetAll()
        {
            return users;
        }

        public void Remove(int id)
        {
            User userToRemove = GetById(id);
            if (userToRemove != null)
            {
                users.Remove(userToRemove);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}
