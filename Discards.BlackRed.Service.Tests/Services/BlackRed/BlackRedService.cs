using System.Linq;

using Discards.BlackRed.Service.Services.BlackRed;

using Xunit;

namespace Discards.BlackRed.Service.Tests.Services.BlackRed
{
	public class BlackRedServiceTests
	{
		public Actions GetService() => new Actions();

		[Fact]
		public void Get()
		{
			var service = GetService();

			var actual = service.Get().Select(q=> q.Card);
		}
	}
}
