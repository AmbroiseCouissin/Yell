using System;
using System.Collections.Generic;
using System.Linq;
using Yell.Models;

namespace Yell.Hosts.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<User> users = InitializeUsers();

            // Initialize the command line application
            while (true)
            {
                for (int i = 0; i < users.Count; i++)
                    Console.WriteLine($"  {i}. Id: {users[i].Id}, Name: {users[i].UserName}");
                Console.WriteLine("Select a user: ");

                while (!int.TryParse(Console.ReadLine(), out int index) || users.ElementAtOrDefault(index) == null)
                    Console.Write("Invalid input. Try again: ");

                User user = users[index];
                Console.WriteLine();
                Console.WriteLine($"Id: {user.Id}, Name: {user.UserName}, Latitude: {user.Position.Item1}, Longitude: {user.Position.Item1}");
                Console.WriteLine();

                Console.Write("What do you want to yell?: ");
                string messageContent = Console.ReadLine();
                Console.WriteLine();

                Console.Write("How loud (in mW per character)?: ");
                while (!decimal.TryParse(Console.ReadLine(), out decimal powerPerCharacterInMilliWatt))
                    Console.Write("Invalid input. Try again: ");
                Console.WriteLine();

                Message message = user.Yell(messageContent, powerPerCharacterInMilliWatt / 1000);
                foreach (User otherUser in users.Where(u => u.Id != user.Id))
                    otherUser.Hear(message);
                Console.WriteLine();
            }
        }

        private static List<User> InitializeUsers() =>
            new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Bambi",
                    Position = new Tuple<double, double>(22.2863943, 114.14913750000005),
                    Ear = new Ear { MinSoundLevel = 15 },
                    Voice = new Voice { RecoveryRate = 0.02m, MaxPower = 0.001m }
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Panpan",
                    Position = new Tuple<double, double>(22.2811673, 114.14244899999994),
                    Ear = new Ear { MinSoundLevel = 15 },
                    Voice = new Voice { RecoveryRate = 0.02m, MaxPower = 0.001m }
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Fleur",
                    Position = new Tuple<double, double>(22.2808373, 114.15567120000003),
                    Ear = new Ear { MinSoundLevel = 15 },
                    Voice = new Voice { RecoveryRate = 0.02m, MaxPower = 0.001m }
                }
            };
    }
}
