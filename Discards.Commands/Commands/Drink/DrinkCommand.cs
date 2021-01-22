using System.Threading.Tasks;

using Discards.Commands.Shared;
using Discards.Services.Services.User.Interfaces;

using Discord.Commands;

namespace Discards.Commands.Commands.Drink
{
	[Alias("Drink")]
	public class DrinkCommand : BaseCommand
	{
		private readonly IUserService _userService;

		public DrinkCommand(IUserService userService)
		{
			_userService = userService;
		}
		[Command]
		public async Task RandomDrink() => await SendMessageAsync(() =>
		{
			_userService.Add(Context.User);
			var user = _userService.GetOne();
			user.Score += 1;

			var msg = $"{user.Mention} Drink!";
			return msg;
		});
		
		[Command("All")]
		public async Task All() => _userService.Get().ForEach(async user =>
		{
			user.Score++;
			await ReplyAsync($"{user.Mention} Drink!");
		});
		
		[Command("Count")]
		public async Task Count(string name) => await SendMessageAsync(() =>
		{
			var user = _userService.GetOne(name);

			var msg = $"{name} took {user?.Score ?? 0} Shots";
			return msg;
		});
	}
}
