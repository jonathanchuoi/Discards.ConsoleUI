using System.Threading.Tasks;
using Discord.WebSocket;

namespace Discards.ConsoleUI.Services
{
	public static class DiscordExtensions
	{
		public static Task Send(this SocketMessage socketMessage, string message)
		{
			return socketMessage.Channel.SendMessageAsync(message);
		}
	}
}