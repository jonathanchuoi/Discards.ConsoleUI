using Discord;

namespace Discards.Commands.Models
{
	public class ReplyModel
	{
		/// <summary>
		/// The message to be sent.
		/// </summary>
		public string Message { get; set; } = null;
		/// <summary>
		/// Determines whether the message should be read aloud by Discord or not.
		/// </summary>
		public bool IsTTS { get; set; } = false;
		/// <summary>
		/// The <see cref="F:Discord.EmbedType.Rich" /> <see cref="T:Discord.Embed" /> to be sent.
		/// </summary>
		public Embed Embed { get; set; } = null;
		/// <summary>
		/// The options to be used when sending the request
		/// </summary>
		public RequestOptions Options { get; set; } = null;
	}
}