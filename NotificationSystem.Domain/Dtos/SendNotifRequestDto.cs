namespace NotificationSystem.Domain.Dtos;

public sealed record SendNotifRequestDto
{
    public string? Destination { get; set; } = string.Empty;
    public string? Message { get; set; } = string.Empty;
}
