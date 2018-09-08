using System;
using System.Threading.Tasks;
using Xunit;

namespace YTBapa.Services.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int min = 100;
            int max = 1000;
            string str = $"min:{min},max:{max}";
            Task.Run(() =>
            {
               var length= str.Length;
            });
        }
    }
}