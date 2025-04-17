using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace OrderService.Services
{
    public class RabbitMQConsumer : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "orderQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[OrderService] Mensagem recebida: {message}");
            };

            channel.BasicConsume(queue: "orderQueue", autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
