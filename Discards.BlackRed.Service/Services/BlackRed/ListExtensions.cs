using System;
using System.Collections.Generic;

namespace Discards.BlackRed.Service.Services.BlackRed
{
	public static class ListExtensions
	{
		private static readonly Random rng = new Random();

		public static void Shuffle<T>(this IList<T> list)
		{
			var n = list.Count;
			while (n > 1)
			{
				n--;
				var k = rng.Next(n + 1);
				var value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}

		public static T Pop<T>(this List<T> list, int index = 0)
		{
			var r = list[index];
			list.RemoveAt(index);
			return r;
		}
	}
}