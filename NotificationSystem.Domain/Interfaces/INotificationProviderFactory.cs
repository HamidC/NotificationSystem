namespace NotificationSystem.Domain.Interfaces;

public interface INotificationProviderFactory
{
    INotificationProvider? GetProvider(string providerName);
    IEnumerable<INotificationProvider?> GetActiveProviders();
}
