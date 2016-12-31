using System;
using System.Collections.Generic;

namespace Yell.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public Tuple<double, double> Position { get; set; }  // Latitude, Longitude

        public Ear Ear { get; set; } = new Ear();
        public Voice Voice { get; set; } = new Voice();
        public List<Message> SentMessages { get; set; } = new List<Message>();

        /// <summary>
        /// Sends a message
        /// </summary>
        /// <param name="content"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public Message Yell(string content, decimal power)
        {
            decimal currentPower = CalculateCurrentVoicePower();
            var message = new Message
            {
                Id = new Guid().ToString(),
                UserId = Id,
                Power = currentPower - power >= 0? power : currentPower,
                Position = Position,
                Content = content,
                DateTime = DateTime.UtcNow
            };

            SentMessages.Add(message);

            Console.WriteLine($"{UserName} yells '{message.Content}' with a power of {message.Power}W.");
            return message;
        }

        /// <summary>
        /// Calculate intesity from the message power and the distance and receive a message if audible.
        /// </summary>
        /// <param name="message"></param>
        public void Hear(Message message)
        {
            double distance = Distances.CalculateHaversine(Position, message.Position);
            double intensity = ((double)message.Power / (4 * Math.PI * Math.Pow(distance, 2))).ToDb();

            if (intensity >= (double)Ear.MinSoundLevel)
                Console.WriteLine($"{UserName} hears '{message.Content}' from a distance of {distance}m at a level {intensity}dB.");
        }

        /// <summary>
        /// Calculate the current voice power based on previous messages and voice recovery
        /// </summary>
        /// <returns></returns>
        private decimal CalculateCurrentVoicePower()
        {
            decimal currentPower = Voice.MaxPower;
            for (int i = 0; i < SentMessages.Count; i++)
            {
                currentPower -= SentMessages[i].Power;
                DateTime nextDate = i + 1 < SentMessages.Count ? SentMessages[i + 1].DateTime : DateTime.UtcNow;
                decimal recoveredPower = (nextDate - SentMessages[i].DateTime).Seconds * Voice.RecoveryRate * Voice.MaxPower;
                currentPower = currentPower + recoveredPower > Voice.MaxPower ? Voice.MaxPower : currentPower + recoveredPower;
            }

            return currentPower;
        }
    }
}
