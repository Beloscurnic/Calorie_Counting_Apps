using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class TokenRevocationBackgroundService : IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Timer? _timer = null;
        private readonly List<string> _revokedTokens;

        public TokenRevocationBackgroundService(IServiceScopeFactory serviceScopeFactory, List<string> revokedTokens)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _revokedTokens = revokedTokens;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(ResetRevokedTokens, null, TimeSpan.Zero, TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private void ResetRevokedTokens(object? state)
        {
            _revokedTokens.Clear();
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            _timer?.Dispose();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
