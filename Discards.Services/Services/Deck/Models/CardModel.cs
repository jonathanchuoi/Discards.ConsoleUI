using Discards.Services.Services.Deck.Enumerations;
using Discards.Shared.Extensions;

namespace Discards.Services.Services.Deck.Models
{
	public class CardModel
	{
		public CardKind Kind { get; set; }
		public CardSuit Suit { get; set; }
		public string Card => $"{Suit} - {Kind}";

		public CardColor? Color => Suit.GetDescription().MapEnum<CardColor>();
	}
}