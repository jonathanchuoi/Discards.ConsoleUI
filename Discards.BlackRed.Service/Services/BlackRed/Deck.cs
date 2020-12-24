using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discards.BlackRed.Service.Models;
using Discards.ConsoleUI.Services;

namespace Discards.BlackRed.Service.Services.BlackRed
{
	public class Deck
	{
		private List<CardModel> _deck = new List<CardModel>();
		private readonly Actions _service;

		public Deck()
		{
			_service = new Actions();
		}

		public void Start()
		{
			_deck = _service.Get();
			Shuffle();
		}

		public void Shuffle() => _deck.Shuffle();
		
		public bool Guess(CardColor color)
		{
			if (!_deck.Any())
			{
				throw new Exception("Deck is empty. Please start a new game with .Restart command");
			}
			var card = _deck.Pop();
			var match = card.Color() == color;
			return match;
		}

		public int Count() => _deck.Count;

		public string Show() => _deck.Select(q => q.Card).ToJsonString();
	}

	public static class ListExtenstions
	{
		private static Random rng = new Random();
		public static void Shuffle<T>(this IList<T> list)  
		{  
			var n = list.Count;  
			while (n > 1) {  
				n--;  
				var k = rng.Next(n + 1);  
				T value = list[k];  
				list[k] = list[n];  
				list[n] = value;  
			}  
		}

		public static T Pop<T>(this List<T> list, int index = 0)
		{
			T r = list[index];
			list.RemoveAt(index);
			return r;
		}
	}
}
