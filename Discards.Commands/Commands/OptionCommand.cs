using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discards.Shared.Extensions;
using Discord;
using Discord.Commands;

namespace Discards.Commands.Commands
{
	[Alias("Option")]
	public class OptionCommand : ModuleBase
	{
		private readonly CommandService _commandService;

		public OptionCommand(CommandService commandService)
		{
			_commandService = commandService;
		}

		[Command]
		public async Task A()
		{
			var msg = _commandService.Modules.SelectMany(q => q.Aliases).ToJsonString();
			await ReplyAsync(msg);
		}

		[Command]
		public async Task B(string option)
		{
			var msg = _commandService.Modules
				.FirstOrDefault(q => q.Aliases
					.Any(r => r.Equals(option, StringComparison.OrdinalIgnoreCase)))?
				.Commands.SelectMany(q => q.Aliases)
				.ToJsonString();
			await ReplyAsync(msg);
		}

	}
}
