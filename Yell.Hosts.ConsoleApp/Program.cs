using System;
using System.Collections.Generic;
using System.Linq;
using Yell.Models;

namespace Yell.Hosts.ConsoleApp
{
    public class Program
    {
        private static List<User> Users { get; set; }

        public static void Main(string[] args)
        {
            // Create a list of users
            Users = new List<User>
            {
                new User
                {
                    Id = "1",
                    UserName = "Bambi",
                    Position = new Tuple<double, double>(22.2863943, 114.14913750000005),
                    Ear = new Ear { MinSoundLevel = 15 },
                    Voice = new Voice { RecoveryRate = 0.02m, MaxPower = 0.001m }
                },
                new User
                {
                    Id = "2",
                    UserName = "Panpan",
                    Position = new Tuple<double, double>(22.2811673, 114.14244899999994),
                    Ear = new Ear { MinSoundLevel = 15 },
                    Voice = new Voice { RecoveryRate = 0.02m, MaxPower = 0.001m }
                },
                new User
                {
                    Id = "3",
                    UserName = "Fleur",
                    Position = new Tuple<double, double>(22.2808373, 114.15567120000003),
                    Ear = new Ear { MinSoundLevel = 15 },
                    Voice = new Voice { RecoveryRate = 0.02m, MaxPower = 0.001m }
                }
            };

            // Initialize the command line application
            while (true)
            {
                Console.Write("Select a user (1, 2 or 3): ");
                string key = Console.ReadKey().KeyChar.ToString();
                while (key != "1" && key != "2" && key != "3")
                {
                    Console.WriteLine();
                    Console.Write("Invalid input. Try again: ");
                    key = Console.ReadKey().KeyChar.ToString();
                }
                Console.WriteLine();

                User user = Users.Find(u => u.Id == key);
                Console.WriteLine();
                Console.WriteLine($"Id: {user.Id}, Name: {user.UserName}, Latitude: {user.Position.Item1}, Longitude: {user.Position.Item1}");
                Console.WriteLine();

                Console.Write("What do you want to yell?: ");
                string messageContent = Console.ReadLine();
                Console.WriteLine();

                Console.Write("How loud (in Watt)?: ");
                while (!decimal.TryParse(Console.ReadLine(), out decimal power))
                    Console.Write("Invalid input. Try again: ");
                Console.WriteLine();

                Message message = user.Yell(messageContent, power);
                foreach (User otherUser in Users.Where(u => u.Id != user.Id))
                    otherUser.Hear(message);
                Console.WriteLine();
            }
        }
    }
}
