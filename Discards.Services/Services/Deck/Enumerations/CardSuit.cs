using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Discards.Services.Services.Deck.Enumerations
{
	[JsonConverter(typeof(StringEnumConverter))] 
	public enum CardSuit
	{
		[Description("♤")] 
		SPADE,
		[Description("♧")] 
		CLUB,
		[Description("♢")] 
		DIAMOND,
		[Description("♡")] 
		HEART
	}
}