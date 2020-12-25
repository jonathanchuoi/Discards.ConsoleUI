using System.Threading.Tasks;
using Discards.Services.Services.BlackRed.Interfaces;
using Discards.Services.Services.Deck.Enumerations;
using Discards.Services.Services.Deck.Interface;
using Discord.Commands;

namespace Discards.Commands.Commands.BlackRed
{
	public class BlackRedCommand : ModuleBase
	{
		private readonly IDeckService _deckService;
		private readonly IBlackRedService _blackRedService;

		public BlackRedCommand(IDeckService deckService, IBlackRedService blackRedService)
		{
			_deckService = deckService;
			_blackRedService = blackRedService;
		}

		[Command("Red")]
		public async Task Red()
		{
			var card = _deckService.DrawFromTop();
			var answer = _blackRedService.Guess(CardColor.RED, card) ? "Correct" : "Wrong";
			var msg = $"{answer} - {card.Card}";
			
			await ReplyAsync(msg);
		}

		[Command("Black")]
		public async Task Black()
		{
			var card = _deckService.DrawFromTop();
			var answer = _blackRedService.Guess(CardColor.BLACK, card) ? "Correct" : "Wrong";
			var msg = $"{answer} - {card.Card}";
			
			await ReplyAsync(msg);
		}
	}

}
