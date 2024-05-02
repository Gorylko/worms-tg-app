using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Worms.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BotController : ControllerBase
{
    [HttpPost("update")]
    public async Task<IActionResult> ExecuteAsync(JsonDocument updateData)
    {
        var chatId = updateData.RootElement.GetProperty("message").GetProperty("chat").GetProperty("id").GetInt64();
        var client = new TelegramBotClient("6826442783:AAG3S9sEfa12d0GlwuSPbuyE9PXhAIKbBSQ");
        await client.SendTextMessageAsync(chatId, "Roma loh?", replyMarkup: new InlineKeyboardMarkup(
            new InlineKeyboardButton[]{ new("Da") { CallbackData = "yes" }, new("Net") { CallbackData = "no" } }));

        return Ok();
    }
}