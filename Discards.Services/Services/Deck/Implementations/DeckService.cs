using System.Collections.Generic;
using System.Linq;

using Discards.Services.Services.Deck.Enumerations;
using Discards.Services.Services.Deck.Interface;
using Discards.Services.Services.Deck.Models;
using Discards.Shared.Extensions;

namespace Discards.Services.Services.Deck.Implementations
{
	public class DeckService : IDeckService
	{
		private List<CardModel> _deck = new List<CardModel>();

		public DeckService()
		{
			Deal();
			Shuffle();
		}

		public void Deal() => _deck = Enumerable.Range(0, 4)
			.SelectMany(suit => Enumerable.Range(1, 13)
				.Select(kind => new CardModel
				{
					Suit = (CardSuit) suit,
					Kind = (CardKind) kind
				})
			).ToList();

		public CardModel DrawFromTop() => _deck.Pop();

		public CardModel DrawFromBottom() => _deck.Pop(_deck.Count);

		public void Shuffle() => _deck = _deck.Shuffle();

		public int Count() => _deck.Count;

		public List<CardModel> Get() => _deck;
	}
}