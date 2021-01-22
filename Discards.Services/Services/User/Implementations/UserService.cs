using System;
using System.Collections.Generic;
using System.Linq;

using Discards.Services.Services.User.Interfaces;
using Discards.Services.Services.User.Models;
using Discards.Shared.Extensions;

using Discord;
using Discord.Commands;

namespace Discards.Services.Services.User.Implementations
{
	public class UserService : IUserService
	{
		private static List<UserModel> _users = new List<UserModel>().Shuffle();

		public void Add(IUser user)
		{
			if (_users.All(q => !q.Mention.Equals(user.Mention, StringComparison.OrdinalIgnoreCase)))
			{
				_users.Add(new UserModel()
				{
					Context = user
				});
			}
		}

		public void Add(string userName)
		{
			if (_users.All(q => !q.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)))
			{
				_users.Add(new UserModel() {UserName = userName});
			}
		}

		public string Invite(ICommandContext context, string id)
		{
			var valid = ulong.TryParse(id, out var uid);
			if (valid == false) throw new Exception("Invalid user id");

			var user = context.Channel.GetUserAsync(uid).Result;
			if (user == null)
			{
				Add(id);
				return id;
			}

			if (!_users.Any(q => q.Mention.Equals(user.Mention, StringComparison.OrdinalIgnoreCase)))
			{
				_users.Add(new UserModel() {Context = user});
			}

			return user.Mention;
		}

		public void Remove(IUser user) => _users = _users.Where(q =>
			!q.UserName.Equals(user.Username, StringComparison.OrdinalIgnoreCase) &&
			!q.Mention.Equals(user.Mention, StringComparison.OrdinalIgnoreCase)).ToList();

		public void Remove(string name) => _users = _users.Where(q =>
			!q.UserName.Equals(name, StringComparison.OrdinalIgnoreCase) &&
			!q.Mention.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

		public UserModel GetOne() => _users.Shuffle().FirstOrDefault();
		public UserModel GetOne(string name) => _users.FirstOrDefault(q => q.UserName == name || q.Mention == name);

		public List<UserModel> Get() => _users;
	}
}
