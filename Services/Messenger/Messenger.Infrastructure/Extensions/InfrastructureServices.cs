using Messenger.Domain.Repositories;
using Messenger.Infrastructure.Data;
using Messenger.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Infrastructure.Extensions
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
            {
                serviceCollection.AddDbContext<ChatDbContext>(options => {
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                });
                serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
                serviceCollection.AddScoped<IChatRepository, ChatRepository>();
                return serviceCollection;
            }
    }
}
