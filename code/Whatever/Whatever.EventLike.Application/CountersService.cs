using System;
using System.Threading.Tasks;

namespace Whatever.EventLike.Application
{
    public class CountersService
    {
        public  Task IncreaseCounter()
        {
            return Task.CompletedTask;
        }
    }
}