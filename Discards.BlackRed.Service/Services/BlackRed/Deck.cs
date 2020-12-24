using System;
using System.Collections.Generic;
using System.Linq;
using Discards.BlackRed.Service.Models;
using Discards.Shared.Extensions;

namespace Discards.BlackRed.Service.Services.BlackRed
{
	public class Deck
	{
		private readonly Actions _service;
		private List<CardModel> _deck = new List<CardModel>();

		public Deck()
		{
			_service = new Actions();
		}

		public void Start()
		{
			_deck = _service.Get();
			Shuffle();
		}

		public void Shuffle()
		{
			_deck.Shuffle();
		}

		public bool Guess(CardColor color)
		{
			if (!_deck.Any()) throw new Exception("Deck is empty. Please start a new game with .Restart command");
			var card = _deck.Pop();
			var match = card.Color() == color;
			return match;
		}

		public int Count()
		{
			return _deck.Count;
		}

		public string Show()
		{
			return _deck.Select(q => q.Card).ToJsonString();
		}
	}
}