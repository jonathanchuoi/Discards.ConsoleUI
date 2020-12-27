using System;
using System.Collections.Generic;
using System.Linq;

namespace Discards.Shared.Extensions
{
	public static class ListExtensions
	{
		public static List<T> Shuffle<T>(this IEnumerable<T> source) => source.OrderBy(q => Guid.NewGuid()).ToList();
	
		public static T Pop<T>(this List<T> source, int index = 0)
		{
			var r = source[index];
			source.RemoveAt(index);
			return r;
		}

	}
}