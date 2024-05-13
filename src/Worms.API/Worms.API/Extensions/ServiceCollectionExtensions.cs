namespace Worms.API.Extensions;

using Microsoft.Extensions.Options;
using Telegram.Bot;
using Worms.API.Settings;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTelegramBot(this IServiceCollection services)
    {
        services.AddSingleton<ITelegramBotClient>(provider =>
        {
            var options = provider.GetRequiredService<IOptions<BotConfigurationSettings>>();

            return new TelegramBotClient(options.Value.Token);
        });
        return services;
    }
    
    public static IServiceCollection RegisterConfigOptions<TSettings>(this IServiceCollection services, string sectionName)
        where TSettings : class
    {
        services.AddOptions<TSettings>()
            .Configure<IConfiguration>((settings, configuration) => configuration.GetSection(sectionName).Bind(settings))
            .ValidateFluentValidation()
            .ValidateOnStart();

        return services;
    }
}