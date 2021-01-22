using Discord;
using Newtonsoft.Json;

namespace Discards.Services.Services.User.Models
{
	public class UserModel
	{
		[JsonIgnore]
		public IUser Context { get; set; }
		
		private string _userName;
		public string UserName
		{
			get => _userName ?? Context.Username;
			set => _userName = value;
		}

		public int Score { get; set; }

		[JsonIgnore]
		public string Mention => (Context != null ? Context.Mention : UserName);
	}
}
