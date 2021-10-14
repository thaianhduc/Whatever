using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Whatever.EventLike.Application.Transport;

namespace Whatever.EventLike.Application.Projection
{
    public class ProjectionBackgroundService : BackgroundService
    {
        private readonly ILogger<ProjectionBackgroundService> _logger;
        private readonly EventChannel _eventChannel;

        public ProjectionBackgroundService(
            ILogger<ProjectionBackgroundService> logger,
            EventChannel eventChannel)
        {
            _logger = logger;
            _eventChannel = eventChannel;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Keep running until asked to stop
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await foreach (var package in _eventChannel.ReadAllAsync(stoppingToken))
                    {
                        // Include the logic to proceed a package here.
                        // A package typical contains the actual event (or events) that the projection needs to project
                        _logger.LogInformation($"Package received: {package.EventName}");
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Bad thing happened");
                }
            }
        }
    }
}