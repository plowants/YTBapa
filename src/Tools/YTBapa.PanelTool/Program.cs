using System;
using System.Collections;
using ServiceStack;
using ServiceStack.Text;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace YTBapa.PanelTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //RabbitMQTest();
            //DateTime time = DateTime.Now;
            //var time2 = SystemTime.UtcNow;

            //Console.WriteLine(TimeSpan.MinValue);
            //Console.WriteLine(time);
            //Console.WriteLine(time2);
            //var t = time.ToUniversalTime() - (new DateTime(1970, 1, 1));
            //long longT = (long)t.TotalMilliseconds;
            //Console.WriteLine(longT);
            //var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            //Console.WriteLine(startTime.AddMilliseconds(longT));

            //TestInput input = new TestInput()
            //{
            //    Time = longT,
            //};
            //var str = input.ToJson<TestInput>();
            //Console.WriteLine(str);
            //var value = JsonSerializer.DeserializeFromString<DateTime>(longT.ToString());
            //Console.WriteLine(value);
            //TestDto dto = str.FromJson<TestDto>();
            //Console.WriteLine(dto.Time);
            
            Task.Run(() =>
                {
                    for(int i=0;i<10;i++){ 
                        Console.Out.WriteLine($"cc work  {i}");
                        Thread.Sleep(1000);
                    }
                }
            );
            Console.WriteLine("Hello World!");
            Console.Read();
        }

        static DateTime ConvertTimestamp(double timestamp)
        {
            DateTime converted = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime newDateTime = converted.AddSeconds(timestamp);
            return newDateTime.ToLocalTime();
        }

        static void RabbitMQTest()
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                UserName = "zhidian",
                Password = "zhidian",
                VirtualHost = "/",
                HostName = "192.168.199.17",
                Port = 5672,
            };
            string exchange = "WholesaleOrder-Cancel1";
            string queue = "Wholesale-WholesaleOrder-OrderCancel1";
            string queueCusstomer = "Wholesale-WholesaleOrder-OrderCancel-Consumer1";

            exchange = "Wholesale-WholesaleOrder";
            queue = "Wholesale-WholesaleOrder-Order";

            //IDictionary<string, object> keys = new Dictionary<string, object>() { { "x-dead-letter-exchange", exchange } };

            var conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();

            channel.ExchangeDeclare(exchange, ExchangeType.Fanout,true);
            channel.QueueDeclare(queue, true, false, false);
            channel.QueueBind(queue, exchange, "");

            //channel.QueueDeclare(queueCusstomer, true, false, false, null);
            //channel.QueueBind(queueCusstomer, exchange, "");
            channel.Close();
            conn.Close();

        }
    }
}