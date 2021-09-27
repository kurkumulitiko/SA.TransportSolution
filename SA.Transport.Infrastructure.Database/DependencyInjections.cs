using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SA.Transport.Core.Application;

namespace SA.Transport.Infrastructure.Database
{
    public static class DependencyInjections
    {
        public static void AddDatabaseLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TransportDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("TransportDBConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
