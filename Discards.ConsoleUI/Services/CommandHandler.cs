using System;
using System.Reflection;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discards.ConsoleUI.Services
{
	public class CommandHandler
	{
		private readonly IConfiguration _config;
		private readonly CommandService _commands;
		private readonly DiscordSocketClient _client;
		private readonly IServiceProvider _services;

		public CommandHandler(IServiceProvider services)
		{
			_config = services.GetRequiredService<IConfiguration>();
			_commands = services.GetRequiredService<CommandService>();
			_client = services.GetRequiredService<DiscordSocketClient>();
			_services = services;

			_commands.CommandExecuted += CommandExecutedAsync;

			_client.MessageReceived += MessageReceivedAsync;
		}

		public async Task InitializeAsync()
		{
			await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
			await _commands.AddModulesAsync(Assembly.Load("Discards.Commands"), _services);
		}
		
		public async Task MessageReceivedAsync(SocketMessage rawMessage)
		{
			if (!(rawMessage is SocketUserMessage message)) return;
			if (message.Source != MessageSource.User) return;
			
			var argPos = 0;
			var prefix = char.Parse(_config["Prefix"]);

			if (!(message.HasMentionPrefix(_client.CurrentUser, ref argPos) || 
			      message.HasCharPrefix(prefix, ref argPos))) return;
			
			var context = new SocketCommandContext(_client, message);

			await _commands.ExecuteAsync(context, argPos, _services); 
		}

		private static async Task CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context,
			IResult result)
		{
			if (!command.IsSpecified)
			{
				Console.WriteLine($"Command [{context?.Message?.Content}] failed to execute for [{context?.User?.Username}] <-> [{result?.ErrorReason}]!");
				return;
			}

			if (result.IsSuccess)
			{
				Console.WriteLine($"Command [{context?.Message?.Content}] executed for -> [{context?.User?.Username}]");
				return;
			}

			if (!result.IsSuccess)
			{
				var msg = $"Command '{context?.Message?.Content}' failed for [{context?.User?.Username}] <-> [{result?.ErrorReason}]!";
				if (context?.Channel != null) await context.Channel?.SendMessageAsync(msg);

				Console.WriteLine(msg);
				return;
			}

			await context.Channel.SendMessageAsync($"Sorry, ... something went wrong -> [{result?.ErrorReason}]!");
		}
	}
}