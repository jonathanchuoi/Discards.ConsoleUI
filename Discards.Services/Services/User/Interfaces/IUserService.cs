using System.Collections.Generic;

using Discards.Services.Services.User.Models;

using Discord;
using Discord.Commands;

namespace Discards.Services.Services.User.Interfaces
{
	public interface IUserService
	{
		void Add(IUser user);
		void Add(string userName);
		string Invite(ICommandContext context, string id);
		void Remove(IUser user);
		void Remove(string name);
		List<UserModel> Get();
		UserModel GetOne();
		UserModel GetOne(string name);
	}
}