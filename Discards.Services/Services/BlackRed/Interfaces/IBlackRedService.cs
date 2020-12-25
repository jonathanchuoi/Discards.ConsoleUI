using Discards.Services.Services.Deck.Enumerations;
using Discards.Services.Services.Deck.Models;

namespace Discards.Services.Services.BlackRed.Interfaces
{
	public interface IBlackRedService
	{
		bool Guess(CardColor expectedColor, CardModel card);
	}
}