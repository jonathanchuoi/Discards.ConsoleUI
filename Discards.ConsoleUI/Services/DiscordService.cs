using System;
using System.Threading.Tasks;

using Discards.Services.Services.BlackRed.Implementations;
using Discards.Services.Services.BlackRed.Interfaces;
using Discards.Services.Services.Deck.Implementations;
using Discards.Services.Services.Deck.Interface;
using Discards.Services.Services.User.Implementations;
using Discards.Services.Services.User.Interfaces;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discards.ConsoleUI.Services
{
	public class DiscordService
	{
		private readonly IConfiguration _config;

		public DiscordService()
		{
			var addJsonFile = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile(path: "appsettings.json");     
			
			_config = addJsonFile.Build();
		}


        public async Task MainAsync()
        {
	        await using var services = ConfigureServices();

	        var client = services.GetRequiredService<DiscordSocketClient>();

	        client.Log += LogAsync;
	        client.Ready += ReadyAsync;
	        services.GetRequiredService<CommandService>().Log += LogAsync;

	        await client.LoginAsync(TokenType.Bot, _config["Token"]);
	        await client.StartAsync();

	        await services.GetRequiredService<CommandHandler>().InitializeAsync();

	        await Task.Delay(-1);
        }

        private static Task LogAsync(LogMessage log)
        {
	        Console.WriteLine(log.ToString());
	        return Task.CompletedTask;
        }

        private static Task ReadyAsync()
        {
            Console.WriteLine("Connected as -> [] :)");
            return Task.CompletedTask;
        }

        private ServiceProvider ConfigureServices() =>
	        new ServiceCollection()
		        .AddSingleton(_config)
		        .AddSingleton<DiscordSocketClient>()
		        .AddSingleton<CommandService>()
		        .AddSingleton<CommandHandler>()
		        .AddSingleton<IDeckService, DeckService>()
		        .AddSingleton<IUserService,UserService>()
		        .AddTransient<IBlackRedService,BlackRedService>()
		        .BuildServiceProvider();
	}
}
