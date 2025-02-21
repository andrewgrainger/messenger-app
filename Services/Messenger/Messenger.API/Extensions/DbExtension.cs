using Microsoft.EntityFrameworkCore;
using Npgsql;
using Polly;

namespace Messenger.API.Extensions;

public static class DbExtension
{
    public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
    {
        using (var scope = host.Services.CreateScope())
        { 
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetService<TContext>();

            try
            {
                logger.LogInformation($"Started Db Migration: {typeof(TContext).Name}");
                
                var retry = Policy.Handle<PostgresException>()
                    .WaitAndRetry(
                        retryCount: 5,
                        sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                        onRetry: (exception, span, count) =>
                        {
                            logger.LogError($"Retrying: {exception} {span}");
                        });
                retry.Execute(() => CallSeeder(seeder, context, services));
                logger.LogInformation($"Migration Complete: {typeof(TContext).Name}");
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, $"Error occurred while migrating db: {typeof(TContext).Name}");
            }
        }

        return host;
    }

    private static void CallSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext? context, IServiceProvider services) where TContext : DbContext
        {
            if (context is null) return;
            context.Database.Migrate();
            seeder(context, services);
        }
}
