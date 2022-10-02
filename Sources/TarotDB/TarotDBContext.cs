using Microsoft.EntityFrameworkCore;

namespace TarotDB;

/// <summary>
/// Database context of the TarotScoreur app
/// </summary>
internal class TarotDBContext : DbContext
{
    public DbSet<PlayerEntity> Players { get; set; }
    public DbSet<GameEntity> Games { get; set; }
    public DbSet<HandEntity> Hands { get; set; }
    public DbSet<BiddingPoigneeEntity> Biddings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=TarotScoreur.db");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.Entity<BiddingPoigneeEntity>().HasKey(b => new { b.Hand, b.Player });
}