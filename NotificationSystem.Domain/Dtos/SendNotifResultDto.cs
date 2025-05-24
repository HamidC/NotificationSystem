namespace NotificationSystem.Domain.Dtos;

public sealed record SendNotifResultDto
{
    public string? Name { get; set; }
    public bool Result { get; set; }
    public Guid? TrackingCode { get; set; }
    public string? Message { get; set; }
}
