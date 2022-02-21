using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EmailSenderExample
{
    class Program
    {
        static async Task Main(string[] args)
        {//Consumer = Tüketici. Mesajı gönderenin gönderdiği mesajları işlem yapan tüketen.


            HubConnection connectionSignalR = new HubConnectionBuilder().WithUrl("https://localhost:5001/messagehub").Build();//SignalR bağlantısı
            await connectionSignalR.StartAsync();


            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://zreirkoo:80Fa-japcFjVWS7-kBG-joOyXDszAZw-@chimpanzee.rmq.cloudamqp.com/zreirkoo");//oluşturduğum cloudAMQP adresini veriyorum
            using IConnection connection = factory.CreateConnection();//RabbitMQ bağlantısı
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare("messagequeue", false, false, false);
            //kuyruğa verdiğim isim.
            //Durable=RabbitMQ da mesaj kalıcı mı kalıcak yoksa resetlenicek mi
            //Exclusive = Birden fazla kanalın bu kuyruğa bağlanıp bağlanamayacağını belirtiyoruz.

            //consumer oluşturmak lazım
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("messagequeue", true, consumer);
            //AutoAck = Kuyruktan alınan mesajın silinip silinmemesini sağlar

            consumer.Received += async (s, e) => //kuyruğa bir mesaj geldiğinde bu mesajı tüketmemizi sağlar
            {
                //Email operasyonu burada gerçekleştirilecektir...
                //e.Body.Span

                string serializeData = Encoding.UTF8.GetString(e.Body.Span);
                User user = JsonSerializer.Deserialize<User>(serializeData);

                EmailSender.Send(user.Email, user.Message);
                Console.WriteLine($"{user.Email} mail gönderilmiştir.");
                await connectionSignalR.InvokeAsync("SendMessageAsync", $"{user.Email} mail gönderilmiştir.");

            };

            Console.Read();
        }
    }
}
