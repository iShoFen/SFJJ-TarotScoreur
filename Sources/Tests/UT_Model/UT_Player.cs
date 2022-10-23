using Model.Players;
using Xunit;

namespace UT_Model
{
    public class UT_Player
    {
        [Theory]
        [InlineData(true, 0, "Florent", "Marques", "Flo", "monAvatar", 0, "Florent", "Marques", "Flo", "monAvatar")]
        [InlineData(true, 0, "Florent", "Marques", "    ", "monAvatar", 0, "Florent", "Marques", "", "monAvatar")]
        [InlineData(true, 1, "     ", "Marques", "Flo", "monAvatar", 1, "", "Marques", "Flo", "monAvatar")]
        [InlineData(true, 2, "     ", "     ", "Flo", "monAvatar", 2, "", "", "Flo", "monAvatar")]
        [InlineData(false, 1, "     ", "     ", "   ", "monAvatar", 1, "", "", "", "monAvatar")]
        [InlineData(true, 1, "Florent", "     ", "Flo", "monAvatar", 1, "Florent", "", "Flo", "monAvatar")]
        [InlineData(false, 1, "Florent", "     ", "     ", "monAvatar", 1, "Florent", "", "", "monAvatar")]
        [InlineData(false, 1, null, null, "     ", "monAvatar", 1, "", "", "", "monAvatar")]
        [InlineData(true, 1, null, null, "Flo", "monAvatar", 1, "", "", "Flo", "monAvatar")]
        [InlineData(false, 1, null, null, null, "monAvatar", 1, "", "", "", "monAvatar")]
        [InlineData(true, 1, "Florent", "Marques", "Flo", "", 1, "Florent", "Marques", "Flo", "")]
        [InlineData(true, 1, "Florent", "Marques", "Flo", null, 1, "Florent", "Marques", "Flo", "")]
        [InlineData(true, 1, "     ", "Marques", "Flo", "    ", 1, "", "Marques", "Flo", "")]
        [InlineData(true, 1, "     ", "     ", "Flo", "    ", 1, "", "", "Flo", "")]
        [InlineData(true, 1, "Florent", "     ", "Flo", "    ", 1, "Florent", "", "Flo", "")]
        [InlineData(true, 1, null, null, "Flo", "", 1, "", "", "Flo", "")]
        public void TestConstructorFull(bool isValid, ulong id, string firstName, string lastName, string nickname,
            string avatar, ulong expectedId,
            string expectedFirstName, string exceptedLastName, string expectedNickname, string expectedAvatar)
        {
            if (isValid)
            {
                Player player = new(id, firstName, lastName, nickname, avatar);
                Assert.Equal(expectedId, player.Id);
                Assert.Equal(expectedFirstName, player.FirstName);
                Assert.Equal(exceptedLastName, player.LastName);
                Assert.Equal(expectedNickname, player.NickName);
                Assert.Equal(expectedAvatar, player.Avatar);
            }
            else
            {
                Assert.ThrowsAny<ArgumentException>(() => new Player(firstName, lastName, nickname, avatar));
            }
        }

        [Fact]
        public void TestConstructor()
        {
            ulong id = 0;
            string firstName = "Florent";
            string lastName = "Marques";
            string nickname = "Flo";
            string avatar = "monAvatar";

            Player player = new(firstName, lastName, nickname, avatar);

            Assert.Equal(id, player.Id);
            Assert.Equal(firstName, player.FirstName);
            Assert.Equal(lastName, player.LastName);
            Assert.Equal(nickname, player.NickName);
            Assert.Equal(avatar, player.Avatar);
        }

        [Theory]
        [MemberData(nameof(PlayerTestData.Data_TestEquals), MemberType = typeof(PlayerTestData))]
        public void TestEquals(bool isEquals, Player player1, object? player2)
        {
            Assert.Equal(isEquals, player1.Equals(player2));
        }

        [Theory]
        [MemberData(nameof(PlayerTestData.Data_TestHashCode), MemberType = typeof(PlayerTestData))]
        public void TestHashCode(bool expectedResult, Player player1, Player player2)
        {
            Assert.Equal(expectedResult, player1.GetHashCode() == player2.GetHashCode());
        }

        [Fact]
        public void TestEqualsNullRef()
        {
            Player player = new(0, "Florent", "MARQUES", "Flo", "avatar");
            Assert.False(player.Equals(null));
        }

        [Theory]
        [MemberData(nameof(PlayerTestData.Data_TestEqualsWithPlayer), MemberType = typeof(PlayerTestData))]
        public void TestEqualsWithPlayer(bool expectedResult, Player player1, Player player2)
        {
            Assert.Equal(expectedResult, player1.Equals(player2));
        }

        [Theory]
        [MemberData(nameof(PlayerTestData.Data_TestFullComparer), MemberType = typeof(PlayerTestData))]
        public void TestEqualsFullComparer(bool expectedResult, Player player1, Player player2)
        {
            Assert.Equal(expectedResult, Player.PlayerFullComparer.Equals(player1, player2));
        }
    }
}