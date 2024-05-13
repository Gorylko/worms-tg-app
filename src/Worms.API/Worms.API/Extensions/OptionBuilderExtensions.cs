namespace Worms.API.Extensions;

using Microsoft.Extensions.Options;
using Worms.API.Extensions.Options;

public static class OptionBuilderExtensions
{
    public static OptionsBuilder<TOptions> ValidateFluentValidation<TOptions>(this OptionsBuilder<TOptions> optionsBuilder)
        where TOptions : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(
            provider => new FluentValidationOptions<TOptions>(
                optionsBuilder.Name, provider));

        return optionsBuilder;
    }
}