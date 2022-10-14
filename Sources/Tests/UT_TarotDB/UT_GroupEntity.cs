using Microsoft.EntityFrameworkCore;
using StubContext;
using Xunit;

namespace UT_TarotDB;

public class UT_GroupEntity
{
    
    
    [Fact]
    public async Task TestRead()
    {
        var options = TestInitializer.InitDb();

        using (var context = new TarotDBContextStub(options))
        {
            context.Database.EnsureCreated();

            var group = await context.Groups
                .Include(g => g.Players)
                .FirstAsync(g => g.Id == 6UL);
            
            Assert.Equal("Group6", group.Name);
            Assert.Equal(5, group.Players.Count);
        }
    }
}