using System.ComponentModel;

namespace Discards.ConsoleUI.Services
{
	public enum BlackRedOptions
	{
		[Description(".Black")]
		BLACK,
		[Description(".Red")]
		RED,
		[Description(".Count")]
		Count,
		[Description(".Shuffle")]
		Shuffle,
		[Description(".Restart")]
		Restart,
		[Description(".Show")]
		Show,
	}
}