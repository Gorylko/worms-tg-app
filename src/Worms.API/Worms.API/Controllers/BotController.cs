using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;

namespace Worms.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BotController : ControllerBase
{
    [HttpPost("update")]
    public async Task<IActionResult> ExecuteAsync(JsonDocument updateData)
    {
        var chatId = updateData.RootElement.GetProperty("message").GetProperty("chat").GetProperty("id").GetInt64();
        var client = new TelegramBotClient("token");
        await client.SendTextMessageAsync(chatId, "message");

        return Ok();
    }
}