namespace Worms.API.Settings;

public class BotConfigurationSettings
{
    public const string SectionName = "BotConfigurationSettings";

    public required string Token { get; init; }
}