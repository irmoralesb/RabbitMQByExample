using System;
using System.Text;
using Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQConsumerService
{
    public class StandardConsumerQueue
    {
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _model;
        private const string QueueName = "StandardQueue_ExampleQueue";

        public StandardConsumerQueue()
        {
            _factory = new ConnectionFactory() { HostName="localhost", UserName = "guest", Password = "guest" };
            _connection = _factory.CreateConnection();
            _model = _connection.CreateModel();
            _model.QueueDeclare(QueueName, true, false, false, null);
        }

        public Person Receive()
        {
            var consumer = new QueueingBasicConsumer(_model);
            _model.BasicConsume(QueueName, true, consumer);
            {
                BasicDeliverEventArgs dequeueObject = consumer.Queue.Dequeue();
                if (dequeueObject != null || dequeueObject.Body != null)
                {
                    var json = Encoding.Default.GetString(dequeueObject.Body);
                    Person person = JsonConvert.DeserializeObject(json, typeof(Person)) as Person;
                    return person;
                }
                return null;
            }

        }

    }
}
