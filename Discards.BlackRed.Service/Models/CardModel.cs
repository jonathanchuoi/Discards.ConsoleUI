namespace Discards.BlackRed.Service.Models
{
	public class CardModel
	{
		public CardKind Kind { get; set; }
		public CardSuit Suit { get; set; }

		public CardColor? Color() => Suit.GetDescription().MapEnum<CardColor>();
		public string Card => $"{Suit} - {Kind}";
	}
}
