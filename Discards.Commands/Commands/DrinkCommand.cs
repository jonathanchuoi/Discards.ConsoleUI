using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Discards.Shared.Extensions;

using Discord.Commands;

namespace Discards.Commands.Commands
{
	public class DrinkCommand : ModuleBase
	{
		public static List<string> users = new List<string>().Shuffle();

		[Command("Drink")]
		public async Task RandomDrink()
		{
			var msg = $"{users.First()} Drink!";
			await ReplyAsync(msg);
		}

		[Command("Drink Add")]
		public async Task Add(string name)
		{
			users.Add(name);
			await ReplyAsync($"{name} Added");
		}
		[Command("Drink All")]
		public async Task All()
		{
			foreach (var user in users)
			{
				var msg = $"{user} Drink!";
				await ReplyAsync(msg);
			}
		}

		[Command("Drink Remove")]
		public async Task Remove(string name)
		{
			users.Remove(name);
			await ReplyAsync($"{name} Removed");
		}

		[Command("Drink Show")]
		public async Task Show()
		{
			var msg = users.ToJsonString();
			await ReplyAsync(msg);
		}
	}

}
