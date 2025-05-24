using NotificationSystem.Application.Factories;
using NotificationSystem.Application.Services;
using NotificationSystem.Domain.Interfaces;

namespace NotificationSystem.API;

public static class ServiceConfiguration
{
    public static IServiceCollection AddNotificationServices(this IServiceCollection services)
    {
        // Main service
        services.AddScoped<INotificationService, NotificationService>();
        
        // Factory
        services.AddScoped<INotificationProviderFactory, NotificationProviderFactory>();
        
        // Notification providers
        services.AddScoped<SmsService>();

        return services;
    }
}
