using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Tarot2B2Model")]

namespace TarotDB;
internal class PlayerEntity
{
    public ulong Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Nickname { get; set; }

    public string Avatar { get; set; }
}