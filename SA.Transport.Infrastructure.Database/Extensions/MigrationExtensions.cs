using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace SA.Transport.Infrastructure.Database.Extensions
{
   
    public static class MigrationExtensions
    {
        /// <summary>
        /// აპლიკაციის გაშვებისას ავტომატურად აგენერირებს ბაზას
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<TransportDBContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return host;
        }
    }
}
