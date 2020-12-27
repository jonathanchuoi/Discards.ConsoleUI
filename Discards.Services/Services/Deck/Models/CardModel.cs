using System;
using System.Text;
using Discards.Services.Services.Deck.Enumerations;
using Discards.Shared.Extensions;

namespace Discards.Services.Services.Deck.Models
{
	public class CardModel
	{
		public CardKind Kind { get; set; }
		public CardSuit Suit { get; set; }
		public string Card => $"{Kind.GetDescription()}{Suit.GetDescription()} - {Kind} OF {Suit}S";

		public CardColor? Color
		{
			get
			{
				switch (Suit)
				{
					case CardSuit.CLUB:
					case CardSuit.SPADE:
						return CardColor.BLACK;
					case CardSuit.DIAMOND:
					case CardSuit.HEART:
						return CardColor.RED;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}
	}
}