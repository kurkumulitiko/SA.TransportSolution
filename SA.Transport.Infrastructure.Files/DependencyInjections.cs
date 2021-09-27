using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SA.Transport.Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Transport.Infrastructure.Files
{
    public static class DependencyInjections
    {
        public static void AddFilesLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFileManager, FileManager>(option => new FileManager(configuration["Files:Address"]));
        }
    }
}
