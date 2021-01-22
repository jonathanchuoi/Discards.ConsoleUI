using System.Threading.Tasks;

using Discards.Services.Services.BlackRed.Interfaces;
using Discards.Services.Services.Deck.Enumerations;
using Discards.Services.Services.Deck.Interface;
using Discards.Services.Services.User.Interfaces;

using Discord;
using Discord.Commands;

namespace Discards.Commands.Commands.BlackRed
{
	[Alias("Draw")]
	public class BlackRedCommand : ModuleBase
	{
		private readonly IDeckService _deckService;
		private readonly IBlackRedService _blackRedService;
		private readonly IUserService _userService;

		public BlackRedCommand(IDeckService deckService, IBlackRedService blackRedService, IUserService userService)
		{
			_deckService = deckService;
			_blackRedService = blackRedService;
			_userService = userService;
		}

		[Command("Red")]
		public async Task Red()
		{
			var card = _deckService.DrawFromTop();
			var answer = _blackRedService.Guess(CardColor.RED, card);

			_userService.Add(Context.User);
			var user = _userService.GetOne(Context.User.Username);
			user.Score += 1;

			var embed = new EmbedBuilder
			{
				Color = Color.Red,
				Description = $"{user.Mention} {(answer ? "is safe this time" : "take a drink!")}",
				Title = card.Card,
			}.Build();

			await ReplyAsync(embed: embed);
		}

		[Command("Black")]
		public async Task Black()
		{
			var card = _deckService.DrawFromTop();
			var answer = _blackRedService.Guess(CardColor.BLACK, card);
			
			_userService.Add(Context.User);
			var user = _userService.GetOne(Context.User.Username);
			user.Score += 1;

			var embed = new EmbedBuilder
			{
				Color = Color.DarkGrey,
				Description = $"{user.Mention} {(answer ? "is safe this time" : "take a drink!")}",
				Title = card.Card,
			}.Build();
			await ReplyAsync(embed:embed);
		}
	}
}
