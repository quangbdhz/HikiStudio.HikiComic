using HikiComic.Utilities.Constants;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;

namespace HikiComic.Application.CacheCleanup
{
    public class CacheCleanupService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IMemoryCache _cache;

        public CacheCleanupService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.Now;
            var endOfDay = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

            var timeUntilEndOfDay = endOfDay - now;
            var delayMilliseconds = (int)timeUntilEndOfDay.TotalMilliseconds;

            #pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            _timer = new Timer(ClearCache, null, delayMilliseconds, Timeout.Infinite);
            #pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Dispose();
            return Task.CompletedTask;
        }

        private void ClearCache(object state)
        {
            _cache.Remove(SystemConstants.AppSettings.KeyExchangeRate);

            var tomorrow = DateTime.Now.AddDays(1);
            var endOfDay = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 23, 59, 59);
            var timeUntilEndOfDay = endOfDay - DateTime.Now;
            var delayMilliseconds = (int)timeUntilEndOfDay.TotalMilliseconds;
            _timer.Change(delayMilliseconds, Timeout.Infinite);
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
