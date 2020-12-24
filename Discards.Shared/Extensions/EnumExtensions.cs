using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Discards.BlackRed.Service.Models
{
	public static class EnumExtensions
	{
		public static string GetDescription(this Enum en)
		{
			var type = en.GetType();
			var memInfo = type.GetMember(en.ToString());
			if (memInfo.Length <= 0) return en.ToString();

			var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
			return attrs.Length > 0 ? ((DescriptionAttribute) attrs[0]).Description : en.ToString();
		}

		public static T? MapEnum<T>(this string stringValue) where T : struct
		{
			var isSuccess = Enum.TryParse(stringValue, true, out T val);

			if (isSuccess)
			{
				return val;
			}

			var enumValues = Enum.GetValues(typeof(T));

			foreach (var v in enumValues)
			{
				if (v is Enum e && string.Equals(e.GetDescription(), stringValue, StringComparison.OrdinalIgnoreCase))
				{
					return ConvertToEnum<T>(e.ToString());
				}
			}

			return null;
		}


		public static T? ConvertToEnum<T>(string src) where T : struct
		{
			if (Enum.TryParse(src, true, out T result)) return result;

			return null;
		}

		public static List<string> GetDataSourceTypes(this Enum value)
		{
			var type = value.GetType();
			return Enum.GetNames(type).ToList();
		}
	}
}