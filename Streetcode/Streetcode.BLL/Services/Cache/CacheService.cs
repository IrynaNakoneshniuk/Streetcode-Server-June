﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;


namespace Streetcode.BLL.Services.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _cache;
        private readonly IConnectionMultiplexer _redis;
        private readonly ILogger<CacheService> _logger;

        public CacheService(IConnectionMultiplexer redis, ILogger<CacheService> logger)
        {
            _redis = redis;
            _cache = _redis.GetDatabase();
            _logger = logger;
        }

        public async Task InvalidateCacheAsync(string pattern)
        {
            try
            {
                var endpoints = _redis.GetEndPoints();
                foreach (var endpoint in endpoints)
                {
                    var server = _redis.GetServer(endpoint);
                    var keys = server.Keys(pattern: pattern + "*").ToArray();

                    if (keys.Any())
                    {
                        foreach (var key in keys)
                        {
                            await _cache.KeyDeleteAsync(key);
                            _logger.LogInformation($"Cache key deleted: {key}");
                        }

                        _logger.LogInformation($"{keys.Length} cache keys invalidated for pattern: {pattern}");
                    }
                    else
                    {
                        _logger.LogInformation($"No cache keys found for pattern: {pattern}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while invalidating cache for pattern: {pattern}");
            }
        }

        public async Task SetCacheAsync(string key, string value, TimeSpan? expiry = null)
        {
            try
            {
                await _cache.StringSetAsync(key, value, expiry);
                _logger.LogInformation($"Cache set for key: {key}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting cache for key: {key}");
            }
        }

        public async Task SetCacheAsync(string key, object value, TimeSpan? expiry = null)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                await _cache.StringSetAsync(key, JsonConvert.SerializeObject(value, settings), expiry);
                _logger.LogInformation($"Cache set for key: {key}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error setting cache for key: {key}");
            }
        }


        public async Task<string?> GetCacheAsync(string key)
        {
            try
            {
                var value = await _cache.StringGetAsync(key);
                _logger.LogInformation($"Cache retrieved for key: {key}");
                return value;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving cache for key: {key}");
                return null;
            }
        }

        public async Task DeleteCacheAsync(string key)
        {
            try
            {
                await _cache.KeyDeleteAsync(key);
                _logger.LogInformation($"Cache key deleted: {key}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting cache for key: {key}");
            }
        }
    }
}
