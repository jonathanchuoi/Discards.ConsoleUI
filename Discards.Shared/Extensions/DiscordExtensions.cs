﻿using System.Threading.Tasks;
using Discord.WebSocket;

namespace Discards.Shared.Extensions
{
	public static class DiscordExtensions
	{
		public static Task Send(this SocketMessage socketMessage, string message) => socketMessage.Channel.SendMessageAsync(message);
	}
}