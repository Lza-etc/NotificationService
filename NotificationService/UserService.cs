using System;
using System.Collections.Generic;

namespace NotificationService
{
    internal class UserService
    {
        private UserRepository userRepository;

        public event Action<string> UserActionOccurred;

        public UserService(UserRepository repository)
        {
            userRepository = repository;
        }

        public void AddUser(User user)
        {
            userRepository.Add(user);
            UserActionOccurred?.Invoke( $"User Added - {user.Id}: {user.Name} ");
        }

        public void UpdateUserProperty(int userId, Action<User> updateAction)
        {
            User userToUpdate = userRepository.GetById(userId);
            Console.WriteLine(userToUpdate);
            if (userToUpdate != null)
            {
                updateAction(userToUpdate);
                UserActionOccurred?.Invoke($"User Updated - {userToUpdate.Id}: {userToUpdate.Name} ");
            }
            else
            {
                Console.WriteLine("User not found.");
                UserActionOccurred?.Invoke("Unknown User");
            }
        }

        public void RemoveUser(int userId)
        {
            var user = userRepository.GetById(userId);
            userRepository.Remove(userId);
            if (user != null )
                UserActionOccurred?.Invoke($"User Removed - {user.Id}: {user.Name} ");
            else
            {
                UserActionOccurred?.Invoke("Unknown User");

            }
        }
    }
}
