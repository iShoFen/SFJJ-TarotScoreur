using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;
using Xunit;

namespace UT_TarotDB;

public class UT_GroupEntity
{
    [Fact]
    public async Task TestRead()
    {
        var options = TestInitializer.InitDb();

        await using var context = new TarotDBContextStub(options);
        await context.Database.EnsureCreatedAsync();

        var group = await context.Groups
            .Include(g => g.Players)
            .FirstAsync(g => g.Id == 6UL);

        Assert.Equal("Group6", group.Name);
        Assert.Equal(5, group.Players.Count);
    }

    [Theory]
    [MemberData(nameof(GroupEntityTestData.Data_TestAdd), MemberType = typeof(GroupEntityTestData))]
    internal async Task TestAdd(string name, IEnumerable<PlayerEntity> players)
    {
        var options = TestInitializer.InitDb();
        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();
            Assert.Empty(context.Groups.Where(g => g.Name == name));

            var group = new GroupEntity
            {
                Name = name,
                Players = players.Select(p => p.Id == 0 ? p : context.Players.Find(p.Id)!).ToHashSet()
            };
            await context.Groups.AddAsync(group);

            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            var fetchGroup = await context.Groups
                .Include(g => g.Players)
                .FirstOrDefaultAsync(g => g.Name == name);

            Assert.NotNull(fetchGroup);
            Assert.Equal(name, fetchGroup!.Name);
            Assert.All(fetchGroup!.Players, p => Assert.Contains(p, context.Players));
            Assert.All(fetchGroup.Players, p => Assert.Contains(fetchGroup, p.Groups));
        }
    }
}