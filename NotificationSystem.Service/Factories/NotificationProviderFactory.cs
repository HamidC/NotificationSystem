using NotificationSystem.Application.Services;
using NotificationSystem.Domain.Interfaces;

namespace NotificationSystem.Application.Factories;

public sealed class NotificationProviderFactory : INotificationProviderFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<string, Type> _activeProviders = [];

    public NotificationProviderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        _activeProviders.Add("KouroshSmsService", typeof(SmsService));
        
        // Later services must be registered here after being developed
        // Examples below:

        //_activeProviders.Add("Email", typeof(EmailService));
        //_activeProviders.Add("Whatsapp", typeof(WhatsappService));
    }

    /// <summary>
    /// Returns the registered notification provider by its given name
    /// </summary>
    /// <param name="providerName"></param>
    /// <returns></returns>
    public INotificationProvider? GetProvider(string providerName)
    {
        if (_activeProviders.TryGetValue(providerName, out var providerType))
        {
            return _serviceProvider.GetService(providerType) as INotificationProvider;
        }
        return null;
    }

    /// <summary>
    /// Returns all registered notification providers
    /// </summary>
    /// <returns></returns>
    public IEnumerable<INotificationProvider?> GetActiveProviders()
    {
        return _activeProviders.Values.Select(x => _serviceProvider.GetService(x) as INotificationProvider);
    }
}
