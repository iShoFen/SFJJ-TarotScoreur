using Microsoft.EntityFrameworkCore;
using StubContext;
using TarotDB;
using Xunit;

namespace UT_TarotDB;

public class UT_UserEntity
{
    [Fact]
    public async Task TestRead()
    {
        var options = TestInitializer.InitDb();

        await using var context = new TarotDBContextStub(options);
        await context.Database.EnsureCreatedAsync();

        var user = await context.Users.FindAsync(13UL);

        Assert.Equal("Anne", user?.FirstName);
        Assert.Equal("SAURIN", user?.LastName);
        Assert.Equal("FRIPOUILLE2", user?.Nickname);
        Assert.Equal("avatar13", user?.Avatar);
        Assert.Equal("email13", user?.Email);
        Assert.Equal("password13", user?.Password);

        var usersWith_ne = context.Users.Where(p => p.FirstName.Contains("ne"));
        Assert.Equal(3, await usersWith_ne.CountAsync());
    }

    [Theory]
    [InlineData(true, 6, "Florent", "MARQUES", "Flo", "avatar1", "email", "password")]
    [InlineData(true, 6, "", "MARQUES", "Flo", "avatar1", "email", "password")]
    [InlineData(true, 6, "Florent", "", "Flo", "avatar1", "email", "password")]
    [InlineData(true, 6, "Florent", "MARQUES", "", "avatar1", "email", "password")]
    [InlineData(true, 6, "Florent", "MARQUES", "Flo", "", "email", "password")]
    [InlineData(true, 6, "Florent", "MARQUES", "Flo", "avatar1", "", "password")]
    [InlineData(true, 6, "Florent", "MARQUES", "Flo", "avatar1", "email", "")]
    [InlineData(true, 6, "", "", "Flo", "avatar1", "email", "password")]
    [InlineData(true, 6, "", "MARQUES", "", "avatar1", "email", "password")]
    [InlineData(true, 6, "", "MARQUES", "Flo", "", "email", "password")]
    [InlineData(true, 6, "", "MARQUES", "Flo", "avatar1", "", "password")]
    [InlineData(true, 6, "", "MARQUES", "Flo", "avatar1", "email", "")]
    [InlineData(true, 6, "Florent", "", "", "avatar1", "email", "password")]
    [InlineData(true, 6, "Florent", "", "Flo", "", "email", "password")]
    [InlineData(true, 6, "Florent", "", "Flo", "avatar1", "", "password")]
    [InlineData(true, 6, "Florent", "", "Flo", "avatar1", "email", "")]
    [InlineData(true, 6, "Florent", "MARQUES", "", "", "email", "password")]
    [InlineData(true, 6, "Florent", "MARQUES", "", "avatar1", "", "password")]
    [InlineData(true, 6, "Florent", "MARQUES", "", "avatar1", "email", "")]
    [InlineData(true, 6, "Florent", "MARQUES", "Flo", "", "", "password")]
    [InlineData(true, 6, "Florent", "MARQUES", "Flo", "", "email", "")]
    [InlineData(true, 6, "Florent", "MARQUES", "Flo", "avatar1", "", "")]
    [InlineData(false, 6, null, "MARQUES", "Flo", "avatar1", "email", "password")]
    [InlineData(false, 6, "Florent", null, "Flo", "avatar1", "email", "password")]
    [InlineData(false, 6, "Florent", "MARQUES", null, "avatar1", "email", "password")]
    [InlineData(false, 6, "Florent", "MARQUES", "Flo", null, "email", "password")]
    [InlineData(true, 6, "Florent", "MARQUES", "Flo", "avatar1", null, "password")]
    [InlineData(true, 6, "Florent", "MARQUES", "Flo", "avatar1", "email", null)]
    [InlineData(false, 6, null, null, "Flo", "avatar1", "email", "password")]
    [InlineData(false, 6, null, "MARQUES", null, "avatar1", "email", "password")]
    [InlineData(false, 6, null, "MARQUES", "Flo", null, "email", "password")]
    [InlineData(false, 6, null, "MARQUES", "Flo", "avatar1", null, "password")]
    [InlineData(false, 6, null, "MARQUES", "Flo", "avatar1", "email", null)]
    [InlineData(false, 6, "Florent", null, null, "avatar1", "email", "password")]
    [InlineData(false, 6, "Florent", null, "Flo", null, "email", "password")]
    [InlineData(false, 6, "Florent", null, "Flo", "avatar1", null, "password")]
    [InlineData(false, 6, "Florent", null, "Flo", "avatar1", "email", null)]
    [InlineData(false, 6, "Florent", "MARQUES", null, null, "email", "password")]
    [InlineData(false, 6, "Florent", "MARQUES", null, "avatar1", null, "password")]
    [InlineData(false, 6, "Florent", "MARQUES", null, "avatar1", "email", null)]
    [InlineData(false, 6, "    ", null, "Flo", "avatar1", "email", "password")]
    [InlineData(false, 6, null, "MARQUES", "    ", "avatar1", "email", "password")]
    [InlineData(false, 6, "Florent", "    ", null, "avatar1", "email", "password")]
    [InlineData(false, 6, "Florent", "    ", null, "avatar1", "email", "    ")]
    [InlineData(false, 6, "Florent", "MARQUES", null, "avatar1", "    ", "password")]
    [InlineData(false, 6, "Florent", "    ", null, "     ", "email", "     ")]
    public async Task TestAdd(bool isValid, int initialUsersCount, string firstname, string lastname,
        string nickname, string avatar, string email, string password)
    {
        var options = TestInitializer.InitDb();

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            await context.Users.AddAsync(new UserEntity
            {
                FirstName = firstname,
                LastName = lastname,
                Nickname = nickname,
                Avatar = avatar,
                Email = email,
                Password = password
            });

            if (isValid)
            {
                await context.SaveChangesAsync();
            }
            else
            {
                await Assert.ThrowsAnyAsync<DbUpdateException>(async () => await context.SaveChangesAsync());
            }
        }

        await using (var context = new TarotDBContextStub(options))
        {
            if (isValid)
            {
                Assert.Equal(initialUsersCount + 1, await context.Users.CountAsync());
                Assert.Equal(1, await context.Users.Where(u => u.FirstName == firstname
                                                               && u.LastName == lastname
                                                               && u.Nickname == nickname
                                                               && u.Avatar == avatar
                                                               && u.Email == email
                                                               && u.Password == password).CountAsync());
            }
            else
            {
                Assert.Equal(initialUsersCount, await context.Users.CountAsync());
            }
        }
    }

    [Theory]
    [InlineData("Florent", "Marques", "Flo", "avatar", "email", "password", "Samuel", "Sirven", "Sam", "mon avatar",
        "monEmail", "monPassword")]
    [InlineData("", "", "Flo", "avatar", "email", "password", "Samuel", "Sirven", "Sam", "mon avatar", "monEmail",
        "monPassword")]
    [InlineData("Florent", "Marques", "Flo", "avatar", "email", "password", "", "", "Sam", "mon avatar", "monEmail",
        "monPassword")]
    public async Task TestUpdate(string firstname, string lastname, string nickname, string avatar, string email,
        string password, string firstname2, string lastname2, string nickname2, string avatar2, string email2,
        string password2)
    {
        var options = TestInitializer.InitDb();

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            await context.Users.AddAsync(new UserEntity
            {
                FirstName = firstname,
                LastName = lastname,
                Nickname = nickname,
                Avatar = avatar,
                Email = email,
                Password = password
            });

            await context.SaveChangesAsync();
        }

        ulong userId;
        await using (var context = new TarotDBContextStub(options))
        {
            var users = context.Users.Where(u => u.FirstName == firstname
                                                 && u.LastName == lastname
                                                 && u.Nickname == nickname
                                                 && u.Avatar == avatar
                                                 && u.Email == email
                                                 && u.Password == password);

            var usersAfter = context.Users.Where(u => u.FirstName == firstname2
                                                      && u.LastName == lastname2
                                                      && u.Nickname == nickname2
                                                      && u.Avatar == avatar2
                                                      && u.Email == email2
                                                      && u.Password == password2);

            Assert.Equal(1, await users.CountAsync());
            Assert.Equal(0, await usersAfter.CountAsync());

            var user = users.Single();
            userId = user.Id;
            user.FirstName = firstname2;
            user.LastName = lastname2;
            user.Nickname = nickname2;
            user.Avatar = avatar2;
            user.Email = email2;
            user.Password = password2;

            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            var users = context.Users.Where(u => u.FirstName == firstname
                                                 && u.LastName == lastname
                                                 && u.Nickname == nickname
                                                 && u.Avatar == avatar
                                                 && u.Email == email
                                                 && u.Password == password);

            var usersAfter = context.Users.Where(u => u.FirstName == firstname2
                                                      && u.LastName == lastname2
                                                      && u.Nickname == nickname2
                                                      && u.Avatar == avatar2
                                                      && u.Email == email2
                                                      && u.Password == password2);

            Assert.Equal(0, await users.CountAsync());
            Assert.Equal(1, await usersAfter.CountAsync());
            Assert.Equal(userId, usersAfter.Single().Id);
        }
    }

    [Theory]
    [InlineData("Florent", "Marques", "Flo", "avatar", "email", "password")]
    [InlineData("", "Marques", "Flo", "avatar", "email", "password")]
    [InlineData("Florent", "", "Flo", "avatar", "email", "password")]
    [InlineData("Florent", "Marques", "", "avatar", "email", "password")]
    [InlineData("Florent", "Marques", "Flo", "", "email", "password")]
    [InlineData("", "", "Flo", "avatar", "email", "password")]
    [InlineData("", "Marques", "", "avatar", "email", "password")]
    [InlineData("", "Marques", "Flo", "", "email", "password")]
    [InlineData("Florent", "", "", "avatar", "email", "password")]
    [InlineData("Florent", "", "Flo", "", "email", "password")]
    [InlineData("Florent", "Marques", "", "", "email", "password")]
    [InlineData("     ", "Marques", "Flo", "avatar", "email", "password")]
    [InlineData("Florent", "     ", "Flo", "avatar", "email", "password")]
    [InlineData("Florent", "Marques", "    ", "avatar", "email", "password")]
    [InlineData("Florent", "Marques", "Flo", "    ", "email", "password")]
    [InlineData("    ", "    ", "    ", "avatar", "email", "password")]
    public async Task TestDelete(string firstname, string lastname, string nickname, string avatar, string email,
        string password)
    {
        var options = TestInitializer.InitDb();

        await using (var context = new TarotDBContextStub(options))
        {
            await context.Database.EnsureCreatedAsync();

            await context.Users.AddAsync(new UserEntity
            {
                FirstName = firstname,
                LastName = lastname,
                Nickname = nickname,
                Avatar = avatar,
                Email = email,
                Password = password
            });

            await context.SaveChangesAsync();
        }

        ulong userId;

        await using (var context = new TarotDBContextStub(options))
        {
            var users = context.Users.Where(u => u.FirstName == firstname
                                                 && u.LastName == lastname
                                                 && u.Nickname == nickname
                                                 && u.Avatar == avatar
                                                 && u.Email == email
                                                 && u.Password == password);

            Assert.Equal(1, await users.CountAsync());

            var user = users.Single();
            userId = user.Id;
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        await using (var context = new TarotDBContextStub(options))
        {
            var users = context.Users.Where(u => u.FirstName == firstname
                                                     && u.LastName == lastname
                                                     && u.Nickname == nickname
                                                     && u.Avatar == avatar
                                                     && u.Email == email
                                                     && u.Password == password);

            Assert.Equal(0, await users.CountAsync());
            Assert.Null(await context.Users.FindAsync(userId));
        }
    }
}