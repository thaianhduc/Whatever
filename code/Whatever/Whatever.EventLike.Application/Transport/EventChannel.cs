using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Whatever.EventLike.Application.Transport
{
    public class EventChannel
    {
        private readonly Channel<EventPackage> _channel;

        public EventChannel()
        {
            var options = new BoundedChannelOptions(10_000)
            {
                SingleReader = true
            };
            _channel = Channel.CreateBounded<EventPackage>(options);
        }

        public IAsyncEnumerable<EventPackage> ReadAllAsync(CancellationToken cancellationToken)
            => _channel.Reader.ReadAllAsync(cancellationToken);

        public async Task Write(EventPackage eventPackage)
        {
            if (await _channel.Writer.WaitToWriteAsync())
            {
                await _channel.Writer.WriteAsync(eventPackage);
            }
        }
    }
}