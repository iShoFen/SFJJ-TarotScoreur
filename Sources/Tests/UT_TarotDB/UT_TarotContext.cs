using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;
using TestUtils;
using Xunit;

namespace UT_TarotDB;

public class UT_TarotContext
{
    public static IEnumerable<object[]> TestConstructor()
    {
        yield return new object[]
        {
            new TarotDbContext(),
            "Data Source=TarotScoreur.db"
        };
        yield return new object[]
        {
            new TarotDbContext(TestInitializer.InitDb()),
            "DataSource=:memory:"
        };
        yield return new object[]
        {
            new TarotDbContextStub(),
            "Data Source=TarotStub.db"
        };
        yield return new object[]
        {
            new TarotDbContextStub(TestInitializer.InitDb()),
            "DataSource=:memory:"
        };
    }

    [Theory]
    [MemberData(nameof(TestConstructor))]
    internal async Task TestDefaultConstructor(TarotDbContext context, string expConnectionString)
    {
        Assert.Equal(expConnectionString, context.Database.GetDbConnection().ConnectionString);

        await context.DisposeAsync();
    }
}