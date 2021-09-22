using Data.Data;
using Data.Repositories;
using Domain.Services.Interfaces;
using Domain.Services.Interfaces.Services;
using Domain.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Crosscutting
{
    public static class Bootstrapper
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Context")));
            services.AddTransient<IGuitarristaService, GuitarristaService>();
            services.AddTransient<IGuitarristaRepository, GuitarristaRepository>();
            services.AddTransient<IGuitarraService, GuitarraService>();
            services.AddTransient<IGuitarraRepository, GuitarraRepository>();

        }
    }
}
