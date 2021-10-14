using System;
using System.Threading.Tasks;
using Whatever.EventLike.Application.Transport;

namespace Whatever.EventLike.Application
{
    public class CountersService
    {
        private readonly EventChannel _eventChannel;

        public CountersService(EventChannel eventChannel)
        {
            _eventChannel = eventChannel;
        }
        public  Task IncreaseCounter()
        {
            return _eventChannel.Write(new EventPackage
            {
                EventName = "CounterIncreased"
            });
        }
    }
}