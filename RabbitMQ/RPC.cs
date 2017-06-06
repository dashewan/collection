using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ
{
    public class RPC
    {
        public static string Send(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "logs", type: "direct");
                    string queueName=channel.QueueDeclare().QueueName;
                    QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
                    var severity = (args.Length > 0) ? args[0] : "info";
                    string message = GetMessage(args);
                    string corrId = Guid.NewGuid().ToString();
                    var body = Encoding.UTF8.GetBytes(message);
                    var properties = channel.CreateBasicProperties();
                    properties.ReplyTo = queueName;
                    properties.CorrelationId = corrId;
                    var messageBytes = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "", routingKey: "rpc_queue", basicProperties: properties, body: messageBytes);
                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                        if (ea.BasicProperties.CorrelationId == corrId)
                        {
                            return Encoding.UTF8.GetString(ea.Body);
                        }
                    }
                }
            }
            
        }
        public static string GetMessage(string[] args)
        {
            return (args.Length > 0) ? string.Join("", args) : "hello World";
        }
    }
}
