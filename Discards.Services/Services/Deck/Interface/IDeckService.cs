using System.Collections.Generic;
using Discards.Services.Services.Deck.Models;

namespace Discards.Services.Services.Deck.Interface
{
	public interface IDeckService
	{
		void Deal();
		CardModel DrawFromTop();
		CardModel DrawFromBottom();
		void Shuffle();
		int Count();
		List<CardModel> Get();
	}
}