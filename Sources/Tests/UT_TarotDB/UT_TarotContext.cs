using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;
using Xunit;
using static UT_TarotDB.TestInitializer;

namespace UT_TarotDB;

public class UT_TarotContext
{

	public static IEnumerable<object[]> TestConstructor()
	{
		yield return new object[]
		{
			new TarotDBContext(),
			"Data Source=TarotScoreur.db"
		};
		yield return new object[]
		{
			new TarotDBContext(InitDb()),
			"DataSource=:memory:"
		};
		yield return new object[]
		{
			new TarotDbContextStub(),
			"Data Source=TarotStub.db"
		};
		yield return new object[]
		{
			new TarotDbContextStub(InitDb()),
			"DataSource=:memory:"
		};
	}
	
	[Theory]
	[MemberData(nameof(TestConstructor))]
	internal async Task TestDefaultConstructor(TarotDBContext context, string expConnectionString)
	{
		Assert.Equal(expConnectionString, context.Database.GetDbConnection().ConnectionString);

		await context.DisposeAsync();
	}
}