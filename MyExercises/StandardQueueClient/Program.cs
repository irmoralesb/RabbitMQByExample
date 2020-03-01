using System;
using Models;
using Factories;
using System.Threading;
using RabbitMQService;

namespace Client.StandardQueue
{
    class Program
    {
        private static StandardClientQueue _queueClient;

        static void Main(string[] args)
        {
            int minSeconds = 0;
            int maxSeconds = 10;
            int seconds = 0;
            var random = new Random(1);
            _queueClient = new StandardClientQueue();
            while (seconds != 10)
            {
                var person = Factories.SchoolMemberFactory.GetSchoolMember();
                seconds = random.Next(minSeconds, maxSeconds);
                Thread.Sleep(seconds * 500);
                _queueClient.SendMessage(person);
                Console.Out.WriteLine($"Name: {person.FirstName} {person.LastName} - {person.Age} years old ({seconds})");
            }
            Console.In.ReadLine();
        }
    }
}
