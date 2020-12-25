using System;
using System.Collections.Generic;

namespace Discards.Shared.Extensions
{
	public static class ListExtensions
	{
		private static readonly Random _random = new Random();
		public static void Shuffle<T>(this IList<T> list)
		{
			for (var i = 0; i < list.Count; i++)
			{
				var k = _random.Next(i + 1);
				var value = list[k];
				list[k] = list[i];
				list[i] = value;
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