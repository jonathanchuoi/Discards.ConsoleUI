using System;
using System.Collections.Generic;
using Discards.BlackRed.Service.Models;

namespace Discards.BlackRed.Service.Services.BlackRed
{
	public class Actions
	{
		public List<CardModel> Get()
		{
			var cards = new List<CardModel>();

			foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
			foreach (CardKind kind in Enum.GetValues(typeof(CardKind)))
				cards.Add(new CardModel
				{
					Kind = kind,
					Suit = suit
				});

			return cards;
		}
	}
}