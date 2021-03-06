﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
namespace RabbitMQSend
{
    public class WorkQueues
    {
        public static void Send(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "task_queue",
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );
                    string message = GetMessage(args);
                    var body = Encoding.UTF8.GetBytes(message);
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    channel.BasicPublish(exchange: "",
                                        routingKey: "task_queue",
                                        basicProperties: properties,
                                        body: body
                                        );
                    Console.WriteLine("[x] Sent {0}", message);
                }
            }
        }
        public static string GetMessage(string[] args)
        {
            return (args.Length > 0) ? string.Join("", args) : "hello World";
        }
    }
}
