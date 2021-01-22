using System.Threading.Tasks;

using Discards.Commands.Shared;
using Discards.Services.Services.User.Interfaces;
using Discards.Shared.Extensions;

using Discord.Commands;

namespace Discards.Commands.Commands.User
{
	[Alias("User")]
	public class UserCommand : BaseCommand
	{
		private readonly IUserService _userService;

		public UserCommand(IUserService userService)
		{
			_userService = userService;
		}

		[Command("Join")]
		public async Task Join() => await SendMessageAsync(() =>
		{
			_userService.Add(Context.User);

			return $"{Context.User.Mention} joined the drinking party";
		});

		[Command("Add")]
		public async Task Add(string userName) => await SendMessageAsync(() =>
		{
			_userService.Add(userName);

			var msg = $"{userName} added to the drinking party";
			return msg;
		});

		[Command("Invite")]
		public async Task Invite(string id) => await SendMessageAsync(() =>
		{
			var user = _userService.Invite(Context, id);

			var msg = $"{user} added to the drinking party";
			return msg;
		});

		[Command("Kick")]
		public async Task Kick(string name) => await SendMessageAsync(() =>
		{
			_userService.Remove(name);
			var msg = $"{name} got kicked out of the party";

			return msg;
		});

		[Command("Leave")]
		public async Task Leave() => await SendMessageAsync(() =>
		{
			_userService.Remove(Context.User);
			var msg = $"{Context.User.Mention} left the party";

			return msg;
		});

		[Command("Show")]
		public async Task Show() => await SendMessageAsync(() =>
		{
			var msg = _userService.Get().ToJsonString();
			return msg;
		});


	}
}
