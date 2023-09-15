using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;

namespace Conversation.Common.Infrastructure
{
    public static class QueueFactory
    {
        public static void SendMessage(string exchangeName, string exchangeType, string queueName, object obj)
        {
            try
            {
                var consumer = CreateBasicConsumer();
                consumer.EnsureExchange(exchangeName, exchangeType).EnsureQueue(queueName, exchangeName);

                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj));
                consumer.Model.BasicPublish(exchangeName, exchangeName, null, body);
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error)
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
        }

        public static EventingBasicConsumer CreateBasicConsumer()
        {
            var factory = new ConnectionFactory()
            {
                HostName = ConversationConstants.RabbitMQHost,
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            return new EventingBasicConsumer(channel);
        }

        public static EventingBasicConsumer EnsureExchange(this EventingBasicConsumer consumer, string exchangeName, string exchangeType = ConversationConstants.DefaultExchangeType)
        {
            consumer.Model.ExchangeDeclare(exchangeName, exchangeType, false, false);
            return consumer;
        }

        public static EventingBasicConsumer EnsureQueue(this EventingBasicConsumer consumer, string queueName, string exchangeName)
        {
            consumer.Model.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            consumer.Model.QueueBind(queueName, exchangeName, queueName);
            return consumer;
        }
    }
}
