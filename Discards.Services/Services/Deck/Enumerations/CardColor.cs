using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Discards.Services.Services.Deck.Enumerations
{
	[JsonConverter(typeof(StringEnumConverter))] 
	public enum CardColor
	{
		BLACK,
		RED
	}
}