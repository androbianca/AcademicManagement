﻿
using BusinessLogic.Abstractions;
using BusinessLogic.Implementations;
using DataAccess.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Configurations
{
   public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddTransient<IAuthLogic, AuthLogic>();
        }
    }
}
