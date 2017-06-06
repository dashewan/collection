using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace RabbitMQReceiving
{
    public class RPC
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
                    foreach (string severity in arg)
                    {
                        channel.QueueBind(queue: queueName, exchange: "logs", routingKey: severity);
                    }

                    // channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        string response = null;
                        var body = ea.Body;
                        var props=ea.BasicProperties;
                        var replyProps = channel.CreateBasicProperties();
                        replyProps.CorrelationId = props.CorrelationId;
                        try
                        {
                            var message = Encoding.UTF8.GetString(body);
                            int n = int.Parse(message);
                            response = fib(n).ToString();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("[.]"+e.Message);
                            response = "";
                        }
                        finally
                        {
                            var responseBytes = Encoding.UTF8.GetBytes(response);
                            channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
                            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                        }
                    };
                    channel.BasicConsume(queue: queueName, noAck: true, consumer: consumer);
                }
            }
        }
        private static int fib(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            return fib(n - 1) + fib(n - 2);
        }
    }
}
