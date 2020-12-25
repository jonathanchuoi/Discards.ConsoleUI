using Discards.Services.Services.BlackRed.Interfaces;
using Discards.Services.Services.Deck.Enumerations;
using Discards.Services.Services.Deck.Models;

namespace Discards.Services.Services.BlackRed.Implementations
{
	public class BlackRedService : IBlackRedService
	{
		public bool Guess(CardColor expectedColor, CardModel card) => card.Color == expectedColor;
	}
}