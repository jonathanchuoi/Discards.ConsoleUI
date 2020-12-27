using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Discards.Services.Services.Deck.Enumerations
{
	[JsonConverter(typeof(StringEnumConverter))] 
	public enum CardKind
	{
		[Description("A")]
		ACE = 1,
		[Description("2")]
		TWO = 2,
		[Description("3")]
		THREE = 3,
		[Description("4")]
		FOUR = 4,
		[Description("5")]
		FIVE = 5,
		[Description("6")]
		SIX = 6,
		[Description("7")]
		SEVEN = 7,
		[Description("8")]
		EIGHT = 8,
		[Description("9")]
		NINE = 9,
		[Description("10")]
		TEN = 10,
		[Description("J")]
		JACK = 11,
		[Description("Q")]
		QUEEN = 12,
		[Description("K")]
		KING = 13
	}
}