using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading;

namespace RabbitMQReceiving
{
    public class Routing
    {
        public static void Receiving(string[] arg)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            string queueName = "";
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "logs", type: "topic");
                    queueName = channel.QueueDeclare().QueueName;
                    foreach(string severity in arg)
                    {
                        channel.QueueBind(queue: queueName, exchange: "logs", routingKey: severity);
                    }
                    
                    // channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("[x] Received {0}", message);
                        int dots = message.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);

                        Console.WriteLine(" [x] Done");

                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    };
                    channel.BasicConsume(queue: queueName, noAck: true, consumer: consumer);
                }
            }
        }
    }
}
