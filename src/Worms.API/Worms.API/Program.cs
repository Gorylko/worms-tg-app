using FluentValidation;
using Worms.API.Extensions;
using Worms.API.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

builder.Services
    .AddValidatorsFromAssemblyContaining<Program>()
    .RegisterConfigOptions<BotConfigurationSettings>(BotConfigurationSettings.SectionName)
    .AddTelegramBot();

var app = builder.Build();

app
    .UseSwagger()
    .UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
