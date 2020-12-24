﻿using System;

using Discards.ConsoleUI.Services;

namespace Discards.ConsoleUI
{
	class Program
	{
			static void Main(string[] args)
		{
			try
			{
				var service = new DiscordService();
				service.MainAsync()
					.GetAwaiter()
					.GetResult();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			finally
			{
				Console.ReadKey();
			}
		}


	}
}
