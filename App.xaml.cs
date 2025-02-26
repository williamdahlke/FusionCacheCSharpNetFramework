using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NeoSmart.Caching.Sqlite;
using System;
using System.IO;
using System.Windows;
using ZiggyCreatures.Caching.Fusion;
using ZiggyCreatures.Caching.Fusion.Backplane;
using ZiggyCreatures.Caching.Fusion.Serialization.NewtonsoftJson;

namespace FusionCacheCSharpNetFramework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            ConfigureServiceProvider();
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        public static void ConfigureServiceProvider()
        {
            IServiceCollection collection = new ServiceCollection();
            collection.AddSqliteCache(e =>
            {
                e.CachePath = Path.Combine(Path.GetTempPath(), "teste_cache.db");
            }, default);

            collection.AddLogging(builder =>
            {
                builder.AddConsole(); // Adiciona o Console como provedor de logs
                builder.SetMinimumLevel(LogLevel.Debug); // Define o nível mínimo de logging
            });

            collection.AddFusionCache(cacheName: "teste")
                .WithDefaultEntryOptions(new FusionCacheEntryOptions()
                {
                    Duration = TimeSpan.FromMinutes(1),
                    IsFailSafeEnabled = true
                })
                .WithLogger(sp => new Logger<FusionCache>(sp.GetRequiredService<ILoggerFactory>()))
                .WithSerializer(new FusionCacheNewtonsoftJsonSerializer())
                .AsKeyedServiceByCacheName()
                .WithRegisteredDistributedCache();

            collection.AddSingleton<ServiceExample>();            

            ServiceProvider = collection.BuildServiceProvider();
        }
    }
}
