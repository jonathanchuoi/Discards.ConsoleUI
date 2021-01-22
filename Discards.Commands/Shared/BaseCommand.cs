using System;
using System.Threading.Tasks;

using Discards.Commands.Models;

using Discord.Commands;

namespace Discards.Commands.Shared
{
	public abstract class BaseCommand : ModuleBase
	{
		public async Task SendMessageAsync(Func<string> reply) =>
			await SendMessageAsync(() => new ReplyModel() {Message = reply()});

		public async Task SendMessageAsync(Func<Task<string>> reply) =>
			await SendMessageAsync(async () => new ReplyModel() {Message = await reply()});

		public async Task SendMessageAsync(Func<Task<ReplyModel>> reply)
		{
			var response = await reply();
			await SendMessageAsync(() => response);
		}

		public async Task SendMessageAsync(Func<ReplyModel> reply)
		{
			var response = reply();
			await ReplyAsync(response.Message, response.IsTTS, response.Embed, response.Options);
		}
	}
}
