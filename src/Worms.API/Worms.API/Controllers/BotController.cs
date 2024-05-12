using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Worms.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BotController : ControllerBase
{
    private readonly ITelegramBotClient _botClient;

    public BotController(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    [HttpPost("update")]
    public async Task<IActionResult> ExecuteAsync(JsonDocument updateData)
    {
        var chatId = updateData.RootElement.GetProperty("message").GetProperty("chat").GetProperty("id").GetInt64();

        await _botClient.SendTextMessageAsync(chatId, "a?", replyMarkup:
            new InlineKeyboardMarkup(
                new InlineKeyboardButton[]{ new("Yep") { CallbackData = "yes" }, new("Nope") { CallbackData = "no" } }));

        return Ok();
    }
}