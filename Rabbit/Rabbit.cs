using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace SistemaProyectos.Rabbit;

public class Rabbit
{
    private readonly IModel _channel;

    public Rabbit()
    {
        var factory = new ConnectionFactory() {HostName = "localhost"};
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();
    }

    public void Publish(string message, string exchange)
    {
        _channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Fanout);
            
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: exchange,
            routingKey: "",
            basicProperties: null,
            body: body);
        Console.WriteLine(" [x] Sent {0}", message);
    }

    public void Receive(string exchange)
    {
        _channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Fanout);

        var queueName = _channel.QueueDeclare().QueueName;
        _channel.QueueBind(queue: queueName,
            exchange: exchange,
            routingKey: "");

        Console.WriteLine(" [*] Waiting for logs.");

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(" [x] {0}", message);
        };
        _channel.BasicConsume(queue: queueName,
            autoAck: true,
            consumer: consumer);
    }
}