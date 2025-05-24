namespace NotificationSystem.Domain.Dtos;

public sealed record SendNotifServiceResultDto
{
    public bool Result { get; set; }
    public Guid? TrackingCode { get; set; }
    public string? ErrorMessage { get; set; }
}
