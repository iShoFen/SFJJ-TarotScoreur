using Microsoft.EntityFrameworkCore;

namespace TarotDB;

/// <summary>
/// Database context of the TarotScoreur app
/// </summary>
internal class TarotDbContext : DbContext
{
    /// <summary>
    /// Table of Players
    /// </summary>
    public DbSet<PlayerEntity> Players { get; set; } = null!;

    /// <summary>
    /// Table of Users
    /// </summary>
    public DbSet<UserEntity> Users { get; set; } = null!;

    /// <summary>
    /// Table of Groups
    /// </summary>
    public DbSet<GroupEntity> Groups { get; set; } = null!;

    /// <summary>
    /// Table of Games
    /// </summary>
    public DbSet<GameEntity> Games { get; set; } = null!;

    /// <summary>
    /// Table of Hands
    /// </summary>
    public DbSet<HandEntity> Hands { get; set; } = null!;

    /// <summary>
    /// Default constructor
    /// </summary>
    public TarotDbContext()
    {
    }

    /// <summary>
    /// Constructor with options
    /// </summary>
    /// <param name="options"> Options </param>
    public TarotDbContext(DbContextOptions<TarotDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Configures the database
    /// </summary>
    /// <param name="optionsBuilder"> Options builder </param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(@"Data Source=TarotScoreur.db");
        }
    }


    /// <summary>
    /// Creates the database
    /// </summary>
    /// <param name="modelBuilder"> Model builder </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the many-to-many relationship between players and hands (add Bidding and Poignee details)
        modelBuilder.Entity<BiddingPoigneeEntity>().HasKey(b => new { b.HandId, b.PlayerId });

        // Configure the many-to-many relationship between players and games
        modelBuilder.Entity<GameEntity>()
            .HasMany(g => g.Players)
            .WithMany(p => p.Games)
            .UsingEntity(gp => gp.ToTable("GamePlayer"));

        // Configure the many-to-many relationship between players and groups
        modelBuilder.Entity<GroupEntity>()
            .HasMany(g => g.Players)
            .WithMany(p => p.Groups)
            .UsingEntity(gp => gp.ToTable("PlayerGroup"));
    }
}