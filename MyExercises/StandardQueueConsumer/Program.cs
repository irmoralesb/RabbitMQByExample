using RabbitMQConsumerService;
using System;
using System.Threading;

namespace Consumer.StandardQueue
{
    class Program
    {
        private static StandardConsumerQueue _queueClient;
        static void Main(string[] args)
        {
            _queueClient = new StandardConsumerQueue();
            while (true)
            {

                var person =  _queueClient.Receive();
                if (person == null)
                {
                    Thread.Sleep(500);
                }
                else
                {
                    Console.Out.WriteLine($"Name: {person.FirstName} {person.LastName} - {person.Age} years old.");
                }

            }
        }
    }
}
