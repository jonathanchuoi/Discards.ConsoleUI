using System.Linq;
using System.Threading.Tasks;
using Discards.Services.Services.Deck.Interface;
using Discards.Shared.Extensions;
using Discord.Commands;

namespace Discards.Commands.Commands.Deck
{
	public class DeckCommand : ModuleBase
	{
		private readonly IDeckService _deckService;

		public DeckCommand(IDeckService deckService)
		{
			_deckService = deckService;
		}

		[Command("Deal")]
		public async Task Deal()
		{
			_deckService.Deal();

			var msg = "Cards Dealt";
			await ReplyAsync(msg);
		}

		[Command("Shuffle")]
		public async Task Shuffle()
		{
			_deckService.Shuffle();

			var msg = "Cards Shuffled";
			await ReplyAsync(msg);
		}

		[Command("Count")]
		public async Task Count()
		{
			var count = _deckService.Count();

			var msg = $"{count} Card{(count == 1 ? "" : "s")} Remaining";
			await ReplyAsync(msg);
		}

		
		[Command("Show")]
		public async Task Show()
		{
			var cards = _deckService.Get();

			var msg = cards.Select(q=> q.Card).ToJsonString();
			await ReplyAsync(msg);
		}

				
		[Command("Peek")]
		public async Task Peek()
		{
			var card =_deckService.Get().FirstOrDefault();

			var msg = card.ToJsonString();
			await ReplyAsync(msg);
		}

		[Command("PeekBottom")]
		public async Task PeekBottom()
		{
			var card =_deckService.Get().LastOrDefault();

			var msg = card.ToJsonString();
			await ReplyAsync(msg);
		}
	}
}
