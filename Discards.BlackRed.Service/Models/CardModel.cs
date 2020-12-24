using Discards.Shared.Extensions;

namespace Discards.BlackRed.Service.Models
{
	public class CardModel
	{
		public CardKind Kind { get; set; }
		public CardSuit Suit { get; set; }
		public string Card => $"{Suit} - {Kind}";

		public CardColor? Color()
		{
			return Suit.GetDescription().MapEnum<CardColor>();
		}
	}
}