using Microsoft.Extensions.DependencyInjection;
using Prodentia.Application.Notifications;
using Prodentia.Infrastructure.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Infrastructure
{
    public static class RegisterInfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        { 
            services.AddScoped<INotifications, EmailService>();
            return services;
        }
    }
}
