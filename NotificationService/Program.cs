// See https://aka.ms/new-console-template for more information
using NotificationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService
{
    class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService(new UserRepository());

            SMSService smsService = new SMSService();
            EmailService emailService = new EmailService();
            PushNotificationService pushNotificationService = new PushNotificationService();

            userService.UserActionOccurred += smsService.Notify;
            userService.UserActionOccurred += emailService.Notify;
            userService.UserActionOccurred += pushNotificationService.Notify;
            int choice;
            do
            {
                DisplayMenu();
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: Console.Write("Name: ");
                            string name= Console.ReadLine(); 
                            Console.Write("Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Contact: ");
                            string contact = Console.ReadLine();
                            userService.AddUser(new User { Name = name, Email = email , Contact=contact});
                            break;
                    case 2:
                            Console.Write("UserId: ");
                            int userId= Convert.ToInt32(Console.ReadLine());

                            switch (UpdateMenu())
                            {
                                case 1:
                                    Console.Write("Name: ");
                                    name = Console.ReadLine();
                                    if(name!=null && name.Length!=0)
                                        userService.UpdateUserProperty(userId, u => u.Name = name);
                                    break;
                                case 2:
                                    Console.Write("Email: ");
                                    email = Console.ReadLine();
                                    if (email != null && email.Length != 0)
                                        userService.UpdateUserProperty(userId, u => u.Email = email);
                                break;
                                case 3:
                                    Console.Write("Contact: ");
                                    contact = Console.ReadLine();
                                    if (contact != null && contact.Length != 0)
                                        userService.UpdateUserProperty(userId, u => u.Contact = contact);
                                    break;
                                default: break;
                            }
                            break;
                    case 3:
                            Console.Write("UserId: ");
                            userId = Convert.ToInt32(Console.ReadLine());
                            userService.RemoveUser(userId);
                            break;
                    case 4:
                            Console.WriteLine("Exited successfully");
                            break;
                    default: Console.WriteLine("Invalid Choice");
                             break;
                }
            } while (choice != 4);

        }
        static void DisplayMenu()
        {
            Console.Write("\n\t\t MAIN MENU");
            Console.Write("\n\n1. Add");
            Console.Write("    2. Update");
            Console.Write("    3. Remove");
            Console.WriteLine("    4. Exit");
        }
        static int UpdateMenu()
        {
            Console.Write("\n\t UPDATE");
            Console.Write("\n1. Name");
            Console.Write("    2. Email");
            Console.WriteLine("    3. Contact");
            Console.Write("Enter your choice: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}

//User u= new User
//{
//    Id = 1,
//    Name = "Test",
//    Contact="12345",
//    Email="emj688531@gmail.com"
//};
//Console.WriteLine(u.ToString());



