using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace SignalR_RabbitMQ_API_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {//Client'tan gelen mesajı karşılayıp RabbitMQ'ya göndericez

        [HttpPost("{message}")]
        public IActionResult Post(string message)
        {

            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://zreirkoo:80Fa-japcFjVWS7-kBG-joOyXDszAZw-@chimpanzee.rmq.cloudamqp.com/zreirkoo");//oluşturduğum cloudAMQP adresini veriyorum
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare("messagequeue", false, false, false);
            //kuyruğa verdiğim isim. Durable=RabbitMQ da mesaj kalıcı mı kalıcak yoksa resetlenicek mi
            //Exclusive = Birden fazla kanalın bu kuyruğa bağlanıp bağlanamayacağını belirtiyoruz.


            byte[] data = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", "messagequeue", body: data);

            return Ok();
        }

    }
}
