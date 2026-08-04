using ELMapper.NET.Services.Implementations;
using ELMapper.NET.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMapper.NET.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddELMapper(this IServiceCollection services)
        {
            services.AddScoped<ELMapperNETService>();

            services.AddScoped<IELMapperNET>(sp =>
                new ELMapperNET(
                    sp.GetRequiredService<ELMapperNETService>()));

            return services;
        }
    }
}
