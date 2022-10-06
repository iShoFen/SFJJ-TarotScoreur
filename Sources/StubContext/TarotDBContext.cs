using Microsoft.EntityFrameworkCore;
using TarotDB;

namespace StubContext;

internal class TarotDBContextStub : TarotDBContext
{
    public TarotDBContextStub(DbContextOptions<TarotDBContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(@"Data Source=TarotStub.db", b => b.MigrationsAssembly("TarotDB"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
            {Id = 1, FirstName = "Jean", LastName = "BON", Nickname = "JEBO", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 2, FirstName = "Jean", LastName = "MOYEN", Nickname = "KIKOU7", Avatar = "avatar2"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 3, FirstName = "Michel", LastName = "BELIN", Nickname = "FRIPOUILLE", Avatar = "avatar3"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 4, FirstName = "Albert", LastName = "GOL", Nickname = "LOL", Avatar = "avatar4"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
                {Id = 5, FirstName = "Julien", LastName = "PETIT", Nickname = "THEGIANT", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
            {Id = 6, FirstName = "Simon", LastName = "SEBAT", Nickname = "SEBAT", Avatar = "avatar2"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 7, FirstName = "Jordan", LastName = "LEG", Nickname = "BIGBRAIN", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 8, FirstName = "Samuel", LastName = "LeChanteur", Nickname = "SS", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 9, FirstName = "Brigitte", LastName = "PUECH", Nickname = "XXFRIPOUILLEXX", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 10, FirstName = "Jeanne", LastName = "LERICHE", Nickname = "JEMA", Avatar = "avatar2"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 11, FirstName = "Jules", LastName = "INFANTE", Nickname = "KIKOU7", Avatar = "avatar3"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 12, FirstName = "Anne", LastName = "SAURIN", Nickname = "FRIPOUILLE", Avatar = "avatar4"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 13, FirstName = "Marine", LastName = "TABLETTE", Nickname = "LOL", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 14, FirstName = "Eliaz", LastName = "DU JARDIN", Nickname = "THEGIANT", Avatar = "avatar2"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 15, FirstName = "Alizee", LastName = "SEBAT", Nickname = "SEBAT", Avatar = "avatar1"});
    }
}