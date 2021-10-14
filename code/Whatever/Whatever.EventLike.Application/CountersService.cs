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
            // Execute whatever the business logic here.
            // And finally, write an event package into the event channel.
            // Imagine there is an actual framework here which will publish events.
            // Those events are then packaged into EventPackage and dispatch
            return _eventChannel.Write(new EventPackage
            {
                EventName = "CounterIncreased"
            });
        }
    }
}