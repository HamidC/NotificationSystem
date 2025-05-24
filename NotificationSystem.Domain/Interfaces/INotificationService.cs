using NotificationSystem.Domain.Dtos;

namespace NotificationSystem.Domain.Interfaces;

public interface INotificationService
{
    public Task<SendNotifResultDto> SendAsync(string providerName, SendNotifRequestDto sendNotifDto);
    public Task<List<SendNotifResultDto>> SendUsingAllMethodsAsync(SendNotifRequestDto sendNotifDto);
}
