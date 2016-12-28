using System;
using System.Collections.Generic;
using Yell.Models;

public class Program
{
    public static List<User> Users { get; set; }

    public static void Main(string[] args)
    {
        Users = new List<User>
        {
            new User
            {
                Id = "1",
                UserName = "Bambi",
                Position = new Tuple<double, double>(22.2863943, 114.14913750000005),
                //Ear = new Ear { EaringDistance = 400 },
                Voice = new Voice { RecoveryRate = 0.00003m, MaxPower = 0.001m }
            },
            new User
            {
                Id = "2",
                UserName = "Panpan",
                Position = new Tuple<double, double>(22.2811673, 114.14244899999994),
                //Ear = new Ear { EaringDistance = 400 },
                Voice = new Voice { RecoveryRate = 0.00003m, MaxPower = 0.001m }
            },
            new User
            {
                Id = "3",
                UserName = "Fleur",
                Position = new Tuple<double, double>(22.2808373, 114.15567120000003),
                //Ear = new Ear { EaringDistance = 400 },
                Voice = new Voice { RecoveryRate = 0.00003m, MaxPower = 0.001m }
            }
        };

        while (true)
        {
            Console.Write("Select a user (1, 2 or 3): ");

            ConsoleKeyInfo key = Console.ReadKey();

            User user = Users.Find(u => u.Id == key.KeyChar.ToString());
            Console.WriteLine();
            Console.WriteLine($"Id: {user.Id}, Name: {user.UserName}, Latitude: {user.Position.Item1}, Longitude: {user.Position.Item1}");
            Console.WriteLine();

            Console.Write("What do you want to yell?: ");
            string messageContent = Console.ReadLine();
            Console.WriteLine();

            Console.Write("How loud (in Watt)?: ");
            decimal power = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();

            Message message = user.Yell(messageContent, power);
            foreach (User u in Users)
                u.Hear(message);

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
