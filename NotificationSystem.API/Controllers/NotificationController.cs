using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Domain.Dtos;
using NotificationSystem.Domain.Interfaces;

namespace NotificationSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    public INotificationService NotificationService { get; private set; }

    public NotificationController(INotificationService notificationService)
    {
        NotificationService = notificationService;
    }


    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Send(string providerName, SendNotifRequestDto sendNotifDto)
    {
        try
        {
            var result = await NotificationService.SendAsync(providerName, sendNotifDto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> SendUsingAllMethods(SendNotifRequestDto sendNotifDto)
    {
        try
        {
            var result = await NotificationService.SendUsingAllMethodsAsync(sendNotifDto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
