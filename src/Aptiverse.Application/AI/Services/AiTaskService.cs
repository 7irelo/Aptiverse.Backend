using Aptiverse.Application.AI.Dtos;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;
using System.Text;
using RabbitMQ.Client;
using System.Text.Json;

namespace Aptiverse.Application.AI.Services
{
    public class AiTaskService(IConfiguration config) : IAiTaskService
    {
        private readonly string _host = config["RabbitMQ:Host"];
        private readonly string _username = config["RabbitMQ:Username"];
        private readonly string _password = config["RabbitMQ:Password"];
        private readonly string _queue = config["RabbitMQ:QueueName"] ?? "ai-tasks";

        public Task SendTaskToQueueAsync(AiTaskPayloadDto taskPayload)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(_host),
                UserName = _username,
                Password = _password
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queue, durable: true, exclusive: false, autoDelete: false);

            var message = JsonSerializer.Serialize(taskPayload);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: "",
                routingKey: _queue,
                basicProperties: null,
                body: body
            );

            return Task.CompletedTask;
        }
    }
}
