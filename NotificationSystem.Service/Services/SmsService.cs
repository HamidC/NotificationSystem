using NotificationSystem.Domain.Dtos;
using NotificationSystem.Domain.Interfaces;

namespace NotificationSystem.Application.Services;

/// <summary>
/// This class wraps all business and logic for accessing a third party notification service.
/// Any future changes originating from said service provider is reflected only here.
/// </summary>
public sealed class SmsService : INotificationProvider
{
    /// <summary>
    /// Provider name is unique for each notification provider that gets implemented.
    /// For example we could have multiple (different) SMS providers implemented in the system.
    /// </summary>
    public string Name => "KouroshSmsService";

    public SmsService()
    {
    }

    /// <summary>
    /// Calls third party services for sending an SMS message
    /// </summary>
    /// <param name="sendNotifDto"></param>
    /// <returns></returns>
    public Task<SendNotifServiceResultDto> SendNotificationAsync(SendNotifRequestDto sendNotifDto)
    {
        var result = new SendNotifServiceResultDto
        {
            TrackingCode = Guid.NewGuid()
        };

        try
        {
            // Example for an exception caused by validation
            if (string.IsNullOrWhiteSpace(sendNotifDto.Destination) || sendNotifDto.Message is null)
                throw new Exception() { };

            // Calling relevant SMS API here

            result.Result = true;
            return Task.FromResult(result);
        }
        catch (Exception ex)
        {
            // Exceptions are handled and a managed DTO is returned with relevant error information
            result.Result = false;
            result.ErrorMessage = ex.Message;

            return Task.FromResult(result);
        }
    }
}
