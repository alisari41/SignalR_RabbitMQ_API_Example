﻿using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EmailSenderExample
{
    class Program
    {
        static void Main(string[] args)
        {//Consumer = Tüketici. Mesajı gönderenin gönderdiği mesajları işlem yapan tüketen.

            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://zreirkoo:80Fa-japcFjVWS7-kBG-joOyXDszAZw-@chimpanzee.rmq.cloudamqp.com/zreirkoo");//oluşturduğum cloudAMQP adresini veriyorum
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare("messagequeue", false, false, false);
            //kuyruğa verdiğim isim.
            //Durable=RabbitMQ da mesaj kalıcı mı kalıcak yoksa resetlenicek mi
            //Exclusive = Birden fazla kanalın bu kuyruğa bağlanıp bağlanamayacağını belirtiyoruz.

            //consumer oluşturmak lazım
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("messagequeue", true, consumer);
            //AutoAck = Kuyruktan alınan mesajın silinip silinmemesini sağlar

            consumer.Received += (s, e) => //kuyruğa bir mesaj geldiğinde bu mesajı tüketmemizi sağlar
            {
                //Email operasyonu burada gerçekleştirilecektir...
                //e.Body.Span
            };


        }
    }
}