using FusionCacheCSharpNetFramework.Data;
using FusionCacheCSharpNetFramework.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using ZiggyCreatures.Caching.Fusion;


namespace FusionCacheCSharpNetFramework
{
    public class ServiceExample
    {
        private readonly IFusionCache _cache;
        private readonly ILogger _logger;

        public ServiceExample(IFusionCacheProvider provider, ILogger<ServiceExample> logger)
        {
            _cache = provider.GetCache("teste");
            _logger = logger;
        }

        public List<Car> Teste()
        {
            _logger.LogDebug("Fazendo GetorSet no cache");
            return _cache.GetOrSet("teste", _ => DatabaseData.GetCars(), TimeSpan.FromMinutes(5));
        }
    }
}
