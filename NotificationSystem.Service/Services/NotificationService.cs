using NotificationSystem.Domain.Dtos;
using NotificationSystem.Domain.Interfaces;

namespace NotificationSystem.Application.Services;

public sealed class NotificationService : INotificationService
{
    private readonly INotificationProviderFactory _factory;

    public NotificationService(INotificationProviderFactory factory)
    {
        _factory = factory;
    }

    /// <summary>
    /// Sends a notification using the given provider name.
    /// Returns false result if provider name is not defined.
    /// </summary>
    /// <param name="providerName"></param>
    /// <param name="sendNotifDto"></param>
    /// <returns></returns>
    public async Task<SendNotifResultDto> SendAsync(string providerName, SendNotifRequestDto sendNotifDto)
    {
        var provider = _factory.GetProvider(providerName);
        if (provider == null)
        {
            return new SendNotifResultDto
            {
                Name = providerName,
                Result = false,
                Message = $"Provider {providerName} is undefined!"
            };
        }

        var sendResult = await provider.SendNotificationAsync(sendNotifDto);
        
        var result = new SendNotifResultDto
        {
            Name = providerName,
            Result = sendResult.Result,
            TrackingCode = sendResult.TrackingCode,
            Message = sendResult.ErrorMessage
        };

        return result;
    }

    /// <summary>
    /// Sends a notification using all registered providers.
    /// Returns a list of results corresponding to each registered provider.
    /// </summary>
    /// <param name="sendNotifDto"></param>
    /// <returns></returns>
    public async Task<List<SendNotifResultDto>> SendUsingAllMethodsAsync(SendNotifRequestDto sendNotifDto)
    {
        List<SendNotifResultDto> result = [];
        var providers = _factory.GetActiveProviders();

        foreach (var provider in providers)
        {
            if (provider == null)
                continue;

            var sendResult = await provider.SendNotificationAsync(sendNotifDto);

            result.Add(new SendNotifResultDto
            {
                Name = provider.Name,
                Result = sendResult.Result,
                TrackingCode = sendResult.TrackingCode,
                Message = sendResult.ErrorMessage
            });
        }

        return result;
    }
}
