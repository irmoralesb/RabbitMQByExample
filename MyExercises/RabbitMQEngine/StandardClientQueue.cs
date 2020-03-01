using System;
using RabbitMQ.Client;
using Models;
using Newtonsoft.Json;
using System.Text;

namespace RabbitMQService
{
    public class StandardClientQueue
    {

        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _model;
        private const string QueueName = "StandardQueue_ExampleQueue";

        public StandardClientQueue()
        {
            _factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            _connection = _factory.CreateConnection();
            _model = _connection.CreateModel();
            _model.QueueDeclare(QueueName, true, false, false, null);
        }

        public void SendMessage(Person person)
        {
            var json = JsonConvert.SerializeObject(person);
            var encoded = Encoding.ASCII.GetBytes(json);
            _model.BasicPublish("", QueueName, null, encoded);
        }

    }
}
