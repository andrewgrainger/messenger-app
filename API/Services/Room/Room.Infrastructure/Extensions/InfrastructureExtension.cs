using Room.Domain.Repositories;
using Room.Infrastructure.Data;
using Room.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Room.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
            {
                serviceCollection.AddDbContext<RoomsDbContext>(options => {
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                });
                serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
                serviceCollection.AddScoped<IRoomRepository, RoomRepository>();
                return serviceCollection;
            }
    }
}