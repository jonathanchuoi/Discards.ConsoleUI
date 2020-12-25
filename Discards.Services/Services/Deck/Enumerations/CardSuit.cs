using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Discards.Services.Services.Deck.Enumerations
{
	[JsonConverter(typeof(StringEnumConverter))] 
	public enum CardSuit
	{
		[Description("BLACK")] 
		SPADE,
		[Description("BLACK")] 
		CLUB,
		[Description("RED")] 
		DIAMOND,
		[Description("RED")] 
		HEART
	}
}