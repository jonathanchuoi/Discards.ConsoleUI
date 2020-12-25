using System;
using System.Collections.Generic;
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

		public void Deal()
		{
			var cards = new List<CardModel>();

			foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
			foreach (CardKind kind in Enum.GetValues(typeof(CardKind)))
			{
				cards.Add(new CardModel
				{
					Kind = kind,
					Suit = suit
				});
			}

			_deck = cards;
		}

		public  CardModel DrawFromTop() => _deck.Pop();

		public CardModel DrawFromBottom() => _deck.Pop(_deck.Count);
		
		public void Shuffle() => _deck.Shuffle();

		public int Count() => _deck.Count;

		public List<CardModel> Get() => _deck;
	}
}