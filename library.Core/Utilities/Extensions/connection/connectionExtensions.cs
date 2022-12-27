using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library.DataLayer.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace library.Core.Utilities.Extensions.connection
{
    public static class connectionExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<dbContext>(options =>
            {
                var connectionString = "ConnectionStrings:vdLibraryConnection:Development";
                options.UseSqlServer(configuration[connectionString]);
            });

            return service;
        }
    }
}
