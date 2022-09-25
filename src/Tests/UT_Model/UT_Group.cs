using Model;
using Xunit;

namespace UT_Model;

public class UT_Group
{
    [Theory]
    [InlineData(true, 3, "partie", 3, "partie")]
    [InlineData(true, 0, "partie", 0, "partie")]
    [InlineData(false, 3, "    ", 3, "")]
    [InlineData(false, 3, "", 3, "")]
    [InlineData(false, 3, null, 3, "")]
    public void TestFullConstructor(bool isValid, ulong id, string name, ulong expectedId, string expectedName)
    {
        if (isValid)
        {
            Group group = new(id, name);
            Assert.Equal(expectedId, group.Id);
            Assert.Equal(expectedName, group.Name);
            Assert.Empty(group.Players);
        }
        else
        {
            Assert.ThrowsAny<ArgumentException>(() => new Group(id, name));
        }
    }

    [Fact]
    public void TestConstructor()
    {
        Group group = new("partie");
        ulong expectedId = 0;

        Assert.Equal(expectedId, group.Id);
        Assert.Equal("partie", group.Name);
        Assert.Empty(group.Players);
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestAddPlayer), MemberType = typeof(GroupTestData))]
    public void TestAddPlayer(bool isValid, Group group, Player player, IEnumerable<Player> expectedPlayers)
    {
        Assert.Equal(isValid, group.AddPlayer(player));
        Assert.Equal(expectedPlayers, group.Players);
    }

    [Fact]
    public void TestAddNullPlayer()
    {
        Group group = new("partie");

        Assert.ThrowsAny<ArgumentException>(() => group.AddPlayer(null!));
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestRemovePlayer), MemberType = typeof(GroupTestData))]
    public void TestRemovePlayer(bool isValid, Group group, Player player, IEnumerable<Player> expectedPlayers)
    {
        Assert.Equal(isValid, group.RemovePlayer(player));
        Assert.Equal(expectedPlayers, group.Players);
    }

    [Theory]
    [MemberData(nameof(GroupTestData.Data_TestClearPlayers), MemberType = typeof(GroupTestData))]
    public void TestClearPlayers(Group group)
    {
        group.ClearPlayers();
        Assert.Empty(group.Players);
    }
}
