using System;
using System.Threading.Tasks;
using Discards.BlackRed.Service.Models;
using Discards.BlackRed.Service.Services.BlackRed;
using Discards.Shared.Extensions;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;

namespace Discards.ConsoleUI.Services
{
	public class DiscordService
	{
		private readonly DiscordSocketClient _client;
		private readonly IConfiguration _config;
		private readonly Deck _deck;

		public DiscordService()
		{
			_client = new DiscordSocketClient();

			//Hook into log event and write it out to the console
			_client.Log += LogAsync;

			//Hook into the client ready event
			_client.Ready += ReadyAsync;

			//Hook into the message received event, this is how we handle the hello world example
			_client.MessageReceived += MessageReceivedAsync;

			//Create the configuration
			var _builder = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile("appsettings.json");
			_config = _builder.Build();

			_deck = new Deck();
			_deck.Start();
		}

		public async Task MainAsync()
		{
			//This is where we get the Token value from the configuration file
			await _client.LoginAsync(TokenType.Bot, _config["Token"]);
			await _client.StartAsync();

			// Block the program until it is closed.
			await Task.Delay(-1);
		}

		private Task LogAsync(LogMessage log)
		{
			Console.WriteLine(log.ToString());
			return Task.CompletedTask;
		}

		private Task ReadyAsync()
		{
			Console.WriteLine("Connected as -> [] :)");
			return Task.CompletedTask;
		}

		//I wonder if there's a better way to handle commands (spoiler: there is :))
		private async Task MessageReceivedAsync(SocketMessage message)
		{
			//This ensures we don't loop things by responding to ourselves (as the bot)
			if (message.Author.Id == _client.CurrentUser.Id) return;

			try
			{
				await BlackRedCommands(message);
			}
			catch (Exception e)
			{
				await message.Send(e.Message);
			}
		}

		private async Task BlackRedCommands(SocketMessage message)
		{
			if (message.Content == ".Red")
			{
				var answer = _deck.Guess(CardColor.RED).ToString();
				await message.Send(answer);
			}
			else if (message.Content == ".Black")
			{
				var isCorrect = _deck.Guess(CardColor.BLACK);
				var answer = isCorrect ? "correct" : "wrong";
				var msg = $"{message.Author.Username} chose .Black and was {answer}";
				await message.Send(answer);
			}
			else if (message.Content.Equals(".Count", StringComparison.OrdinalIgnoreCase))
			{
				var count = _deck.Count().ToString();
				await message.Send(count);
			}
			else if (message.Content.Equals(".Shuffle", StringComparison.OrdinalIgnoreCase))
			{
				_deck.Start();
				await message.Send("Shuffle: Ok");
			}
			else if (message.Content.Equals(".Restart", StringComparison.OrdinalIgnoreCase))
			{
				_deck.Start();
				await message.Send("Ok");
			}
			else if (message.Content.Equals(".Show", StringComparison.OrdinalIgnoreCase))
			{
				var cards = _deck.Show();
				await message.Send(cards);
			}
		}
	}
}