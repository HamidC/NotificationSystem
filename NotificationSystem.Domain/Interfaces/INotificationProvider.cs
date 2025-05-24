using NotificationSystem.Domain.Dtos;

namespace NotificationSystem.Domain.Interfaces;

public interface INotificationProvider
{
    string Name { get; }

    Task<SendNotifServiceResultDto> SendNotificationAsync(SendNotifRequestDto sendNotifDto);
}
