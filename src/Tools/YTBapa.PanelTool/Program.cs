using System;
using ServiceStack;
using ServiceStack.Text;
using RabbitMQ.Client;

namespace YTBapa.PanelTool
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = DateTime.Now;
            var  time2 = SystemTime.UtcNow;

            Console.WriteLine(TimeSpan.MinValue);
            Console.WriteLine(time);
            Console.WriteLine(time2);
            var t = time.ToUniversalTime() - (new DateTime(1970, 1, 1));
            long longT = (long)t.TotalMilliseconds;
            Console.WriteLine(longT);
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            Console.WriteLine(startTime.AddMilliseconds(longT));

            TestInput input = new TestInput()
            {
                Time = longT,
            };
            var str = input.ToJson<TestInput>();
            Console.WriteLine(str);
            var value = JsonSerializer.DeserializeFromString<DateTime>(longT.ToString());
            Console.WriteLine(value);
            TestDto dto = str.FromJson<TestDto>();
            Console.WriteLine(dto.Time);
            Console.WriteLine("Hello World!");
            Console.Read();
        }

        static DateTime ConvertTimestamp(double timestamp)
        {
            DateTime converted = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime newDateTime = converted.AddSeconds(timestamp);
            return newDateTime.ToLocalTime();
        }
    }
}