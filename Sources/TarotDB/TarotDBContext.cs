using Microsoft.EntityFrameworkCore;

namespace TarotDB;

/// <summary>
/// Database context of the TarotScoreur app
/// </summary>
internal class TarotDBContext : DbContext
{
    public DbSet<PlayerEntity> Players { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=TarotScoreur.db");
}