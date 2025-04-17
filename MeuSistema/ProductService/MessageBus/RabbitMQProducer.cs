using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ProductService.MessageBus
{
    public class RabbitMQProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "orderQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "orderQueue", basicProperties: null, body: body);
        }
    }
}
