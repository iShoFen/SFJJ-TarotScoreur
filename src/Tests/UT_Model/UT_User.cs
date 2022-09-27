using System.Globalization;
using Microsoft.VisualBasic.CompilerServices;
using Model;
using Xunit;

namespace UT_Model;

public class UT_User
{
    [Theory]
    [InlineData(true, 0, "Florent", "Marques", "Flo", "monAvatar", "email", "password", 0, "Florent", "Marques", "Flo",
        "monAvatar", "email", "password")]
    [InlineData(true, 0, "Florent", "Marques", "Flo", "monAvatar", "     ", "password", 0, "Florent", "Marques", "Flo",
        "monAvatar", "", "password")]
    [InlineData(true, 0, "Florent", "Marques", "Flo", "monAvatar", "email", "     ", 0, "Florent", "Marques", "Flo",
        "monAvatar", "email", "")]
    [InlineData(true, 0, "Florent", "Marques", "Flo", "monAvatar", "    ", "      ", 0, "Florent", "Marques", "Flo",
        "monAvatar", "", "")]
    [InlineData(true, 0, "Florent", "Marques", "Flo", "monAvatar", null, "password", 0, "Florent", "Marques", "Flo",
        "monAvatar", "", "password")]
    [InlineData(true, 0, "Florent", "Marques", "Flo", "monAvatar", "email", null, 0, "Florent", "Marques", "Flo",
        "monAvatar", "email", "")]
    [InlineData(true, 0, "Florent", "Marques", "Flo", "monAvatar", null, null, 0, "Florent", "Marques", "Flo",
        "monAvatar", "", "")]
    [InlineData(true, 0, "Florent", "Marques", "    ", "monAvatar", "email", "password", 0, "Florent", "Marques", "",
        "monAvatar", "email", "password")]
    [InlineData(true, 1, "     ", "Marques", "Flo", "monAvatar", "email", "password", 1, "", "Marques", "Flo",
        "monAvatar", "email", "password")]
    [InlineData(true, 2, "     ", "     ", "Flo", "monAvatar", "email", "password", 2, "", "", "Flo", "monAvatar",
        "email", "password")]
    [InlineData(false, 1, "     ", "     ", "   ", "monAvatar", "email", "password", 1, "", "", "", "monAvatar",
        "email", "password")]
    [InlineData(true, 1, "Florent", "     ", "Flo", "monAvatar", "email", "password", 1, "Florent", "", "Flo",
        "monAvatar", "email", "password")]
    [InlineData(false, 1, "Florent", "     ", "     ", "monAvatar", "email", "password", 1, "Florent", "", "",
        "monAvatar", "email", "password")]
    [InlineData(false, 1, null, null, "     ", "monAvatar", "email", "password", 1, "", "", "", "monAvatar", "email",
        "password")]
    [InlineData(true, 1, null, null, "Flo", "monAvatar", "email", "password", 1, "", "", "Flo", "monAvatar", "email",
        "password")]
    [InlineData(false, 1, null, null, null, "monAvatar", "email", "password", 1, "", "", "", "monAvatar", "email",
        "password")]
    [InlineData(true, 1, "Florent", "Marques", "Flo", "", "email", "password", 1, "Florent", "Marques", "Flo", "",
        "email", "password")]
    [InlineData(true, 1, "Florent", "Marques", "Flo", null, "email", "password", 1, "Florent", "Marques", "Flo", "",
        "email", "password")]
    [InlineData(true, 1, "     ", "Marques", "Flo", "    ", "email", "password", 1, "", "Marques", "Flo", "", "email",
        "password")]
    [InlineData(true, 1, "     ", "     ", "Flo", "    ", "email", "password", 1, "", "", "Flo", "", "email",
        "password")]
    [InlineData(true, 1, "Florent", "     ", "Flo", "    ", "email", "password", 1, "Florent", "", "Flo", "", "email",
        "password")]
    [InlineData(true, 1, null, null, "Flo", "", "email", "password", 1, "", "", "Flo", "", "email", "password")]
    public void TestFullConstructor(bool isValid, ulong id, string firstName, string lastName, string nickname,
        string avatar, string email, string password, ulong expectedId,
        string expectedFirstName, string exceptedLastName, string expectedNickname, string expectedAvatar,
        string expectedEmail, string expectedPassword)
    {
        if (isValid)
        {
            User user = new User(id, firstName, lastName, nickname, avatar, email, password);

            Assert.Equal(expectedId, user.Id);
            Assert.Equal(expectedFirstName, user.FirstName);
            Assert.Equal(exceptedLastName, user.LastName);
            Assert.Equal(expectedNickname, user.NickName);
            Assert.Equal(expectedAvatar, user.Avatar);
            Assert.Equal(expectedEmail, user.Email);
            Assert.Equal(expectedPassword, user.Password);
        }
        else
        {
            Assert.ThrowsAny<ArgumentException>(() =>
                new User(id, firstName, lastName, nickname, avatar, email, password));
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
        string email = "email";
        string password = "password";

        User user = new User(id, firstName, lastName, nickname, avatar, email, password);

        Assert.Equal(id, user.Id);
        Assert.Equal(firstName, user.FirstName);
        Assert.Equal(lastName, user.LastName);
        Assert.Equal(nickname, user.NickName);
        Assert.Equal(avatar, user.Avatar);
        Assert.Equal(email, user.Email);
        Assert.Equal(password, user.Password);
    }

    [Theory]
    [MemberData(nameof(UserTestData.Data_TestEquals), MemberType = typeof(UserTestData))]
    public void TestEquals(bool isEquals, User user1, object? user2)
    {
        Assert.Equal(isEquals, user1.Equals(user2));
    }

    [Theory]
    [MemberData(nameof(UserTestData.Data_TestEqualsWithUser), MemberType = typeof(UserTestData))]
    public void TestEqualsWithUser(bool isEquals, User user1, User? user2)
    {
        Assert.Equal(isEquals, user1.Equals(user2));
    }
    
    [Theory]
    [MemberData(nameof(UserTestData.Data_TestFullComparer), MemberType = typeof(UserTestData))]
    public void TestEqualsFullComparer(bool isEquals, User? user1, User? user2)
    {
        Assert.Equal(isEquals, User.UserFullComparer.Equals(user1, user2));
    }

    [Theory]
    [MemberData(nameof(UserTestData.Data_TestHashCode), MemberType = typeof(UserTestData))]
    public void TestHashCode(bool isExpected, User user1, User user2)
    {
        Assert.Equal(isExpected, user1.GetHashCode() == user2.GetHashCode());
    }
}