using Microsoft.EntityFrameworkCore;
using TarotDB;
using TarotDB.enums;

namespace StubContext;

internal class TarotDBContextStub : TarotDBContext
{
    public TarotDBContextStub(DbContextOptions<TarotDBContext> options) : base(options) { }

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
        AddPlayers(modelBuilder);
        AddGroups(modelBuilder);
        AddGames(modelBuilder);
        AddHands(modelBuilder);
    }

    private void AddPlayers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
            {Id = 1, FirstName = "Jean", LastName = "BON", Nickname = "JEBO", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
                {Id = 2, FirstName = "Jean", LastName = "MAUVAIS", Nickname = "JEMA", Avatar = "avatar2"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
                {Id = 3, FirstName = "Jean", LastName = "MOYEN", Nickname = "KIKOU7", Avatar = "avatar3"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
                {Id = 4, FirstName = "Michel", LastName = "BELIN", Nickname = "FRIPOUILLE", Avatar = "avatar4"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
                {Id = 5, FirstName = "Albert", LastName = "GOL", Nickname = "LOL", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
                {Id = 6, FirstName = "Julien", LastName = "PETIT", Nickname = "THEGIANT", Avatar = "avatar2"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
                {Id = 7, FirstName = "Simon", LastName = "SEBAT", Nickname = "SEBAT", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
                {Id = 8, FirstName = "Jordan", LastName = "LEG", Nickname = "BIGBRAIN", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
                {Id = 9, FirstName = "Samuel", LastName = "LeChanteur", Nickname = "SS", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
                {Id = 10, FirstName = "Brigitte", LastName = "PUECH", Nickname = "XXFRIPOUILLEXX", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
                {Id = 11, FirstName = "Jeanne", LastName = "LERICHE", Nickname = "JEMA", Avatar = "avatar2"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
                {Id = 12, FirstName = "Jules", LastName = "INFANTE", Nickname = "KIKOU7", Avatar = "avatar3"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
                {Id = 13, FirstName = "Anne", LastName = "SAURIN", Nickname = "FRIPOUILLE", Avatar = "avatar4"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
                {Id = 14, FirstName = "Marine", LastName = "TABLETTE", Nickname = "LOL", Avatar = "avatar1"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity 
                {Id = 15, FirstName = "Eliaz", LastName = "DU JARDIN", Nickname = "THEGIANT", Avatar = "avatar2"});
        modelBuilder.Entity<PlayerEntity>().HasData(new PlayerEntity
                {Id = 16, FirstName = "Alizee", LastName = "SEBAT", Nickname = "SEBAT", Avatar = "avatar1"});
    }

    private void AddGroups(ModelBuilder modelBuilder)
    {
        for (var i = 1UL; i < 13UL; ++i)
        {
            modelBuilder.Entity<GroupEntity>().HasData(new GroupEntity {Id = i, Name = $"Group{i}"});
        }

        // TODO Find a way to fill the join table between groups and players commented code doesn't work
        /*var playerGroup = new List<object>();
        for (var i = 1UL; i < 13; ++i)
        {
            for (var j = i; j < 6UL; ++j)
            {
               playerGroup.Add(new {GroupsId = i, PlayersId = j});
            }
        }

        modelBuilder.Entity<GroupEntity>()
            .HasMany(g => g.Players)
            .WithMany(p => p.Groups)
            .UsingEntity(gp => gp.ToTable("PlayerGroup"))
            .HasData(playerGroup);*/
    }

    private void AddGames(ModelBuilder modelBuilder)
    {
        
        
        modelBuilder.Entity<GameEntity>().HasData(new GameEntity 
            {Id = 1UL, Name = "Game1", Rules = "FrenchTarotRules", StartDate = DateTime.Now});
        modelBuilder.Entity<GameEntity>().HasData(new GameEntity
                {Id = 2UL, Name = "Game2", Rules = "FrenchTarotRules", StartDate = DateTime.Now});
        modelBuilder.Entity<GameEntity>().HasData(new GameEntity 
                {Id = 3UL, Name = "Game3", Rules = "FrenchTarotRules", StartDate = DateTime.Now});
        modelBuilder.Entity<GameEntity>().HasData(new GameEntity  
                {Id = 4UL, Name = "Game4", Rules = "FrenchTarotRules", StartDate = DateTime.Now});
        modelBuilder.Entity<GameEntity>().HasData(new GameEntity 
                {Id = 5UL, Name = "Game5", Rules = "FrenchTarotRules", StartDate = DateTime.Now});
        modelBuilder.Entity<GameEntity>().HasData(new GameEntity 
            {Id = 6UL, Name = "Game13", Rules = "FrenchTarotRules", 
                StartDate = new DateTime(2022, 09, 21), EndDate = new DateTime(2022, 09, 25)});
        modelBuilder.Entity<GameEntity>().HasData(new GameEntity 
            {Id = 7UL, Name = "Game14", Rules = "FrenchTarotRules", 
                StartDate = new DateTime(2022, 09, 21), EndDate = new DateTime(2022, 09, 25)});
        modelBuilder.Entity<GameEntity>().HasData(new GameEntity
            {Id = 8UL, Name = "Game15", Rules = "FrenchTarotRules", 
                StartDate = new DateTime(2022, 09, 21), EndDate = new DateTime(2022, 09, 25)});
        modelBuilder.Entity<GameEntity>().HasData(new GameEntity 
            {Id = 9UL, Name = "Game16", Rules = "FrenchTarotRules", 
                StartDate = new DateTime(2022, 09, 21), EndDate = new DateTime(2022, 09, 25)});
        modelBuilder.Entity<GameEntity>().HasData(new GameEntity 
            {Id = 10UL, Name = "Game17", Rules = "FrenchTarotRules", 
                StartDate = new DateTime(2022, 09, 18), EndDate = new DateTime(2022, 09, 23)});
        
        // TODO Find a way to fill the join table between games and players commented code doesn't work
        // AddPlayersGame(1UL, 3UL, 3UL, modelBuilder);
        // AddPlayersGame(4UL, 3UL, 4UL, modelBuilder);
        // AddPlayersGame(7UL, 4UL, 5UL, modelBuilder);
    }
    
    private void AddPlayersGame(ulong startG, ulong nbG, ulong nbP, ModelBuilder modelBuilder)
    {
        var gamePlayer = new List<object>();
        for (var i = startG; i < nbG + 1UL; ++i)
        {
            for (var j = i; j < nbP + 1UL; ++j)
            {
                gamePlayer.Add(new {GamesId = i, PlayersId = j});
            }
        }
        
        modelBuilder.Entity<GameEntity>()
            .HasMany(g => g.Players)
            .WithMany(p => p.Games)
            .UsingEntity(gp => gp.ToTable("GamePlayer"))
            .HasData(gamePlayer);
    }

    private void AddHands(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HandEntity>().HasData(new {Id = 1UL, Number = 1, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 210, TwentyOne = false, Excuse = true, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.Unknown, GameId = 1UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 2UL, Number = 2, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 22), 
                TakerScore = 256, TwentyOne = true, Excuse = true, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.AnnouncedSuccess, GameId = 1UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 3UL, Number = 3, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 23), 
                TakerScore = 151, TwentyOne = false, Excuse = false, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.Success, GameId = 1UL});
        
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 4UL, Number = 1, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 561, TwentyOne = false, Excuse = false, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.Unknown, GameId = 2UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 5UL, Number = 2, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 256, TwentyOne = false, Excuse = true, Petit = PetitResultDB.AuBoutOwned, 
                Chelem = ChelemDB.AnnouncedSuccess, GameId = 2UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 6UL, Number = 3, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 151, TwentyOne = true, Excuse = false, Petit = PetitResultDB.Owned, 
                Chelem = ChelemDB.Success, GameId = 2UL});

        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 7UL, Number = 1, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 567, TwentyOne = true, Excuse = true, Petit = PetitResultDB.LostAuBout, 
                Chelem = ChelemDB.Unknown, GameId = 3UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 8UL, Number = 2, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 27), 
                TakerScore = 256, TwentyOne = false, Excuse = true, Petit = PetitResultDB.AuBoutOwned, 
                Chelem = ChelemDB.Success, GameId = 3UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 9UL, Number = 3, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 30), 
                TakerScore = 654, TwentyOne = false, Excuse = false, Petit = PetitResultDB.Owned, 
                Chelem = ChelemDB.Success, GameId = 3UL});
        
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 10UL, Number = 1, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 16), 
                TakerScore = 567, TwentyOne = false, Excuse = false, Petit = PetitResultDB.NotOwned, 
                Chelem = ChelemDB.AnnouncedSuccess, GameId = 4UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 11UL, Number = 2, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 365, TwentyOne = false, Excuse = true, Petit = PetitResultDB.AuBoutOwned, 
                Chelem = ChelemDB.Fail, GameId = 4UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 12UL, Number = 3, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 28), 
                TakerScore = 151, TwentyOne = true, Excuse = false, Petit = PetitResultDB.AuBoutOwned, 
                Chelem = ChelemDB.Success, GameId = 4UL});
        
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 13UL, Number = 1, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 567, TwentyOne = true, Excuse = false, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.Unknown, GameId = 5UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 14UL, Number = 2, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 567, TwentyOne = false, Excuse = false, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.AnnouncedSuccess, GameId = 5UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 15UL, Number = 3, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 25), 
                TakerScore = 151, TwentyOne = true, Excuse = true, Petit = PetitResultDB.Owned, 
                Chelem = ChelemDB.Success, GameId = 5UL});
        
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 16UL, Number = 1, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 873, TwentyOne = false, Excuse = true, Petit = PetitResultDB.LostAuBout, 
                Chelem = ChelemDB.Fail, GameId = 6UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 17UL, Number = 2, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 25), 
                TakerScore = 567, TwentyOne = true, Excuse = false, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.AnnouncedSuccess, GameId = 6UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 18UL, Number = 3, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 27), 
                TakerScore = 151, TwentyOne = true, Excuse = true, Petit = PetitResultDB.Owned, 
                Chelem = ChelemDB.AnnouncedSuccess, GameId = 6UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 19UL, Number = 4, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 29), 
                TakerScore = 567, TwentyOne = true, Excuse = false, Petit = PetitResultDB.Owned, 
                Chelem = ChelemDB.Unknown, GameId = 6UL});
        
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 20UL, Number = 1, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 567, TwentyOne = false, Excuse = false, Petit = PetitResultDB.LostAuBout, 
                Chelem = ChelemDB.Unknown, GameId = 7UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 21UL, Number = 2, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 826, TwentyOne = false, Excuse = false, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.AnnouncedSuccess, GameId = 7UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 22UL, Number = 3, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 29), 
                TakerScore = 745, TwentyOne = true, Excuse = true, Petit = PetitResultDB.Owned, 
                Chelem = ChelemDB.Success, GameId = 7UL});
        
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 23UL, Number = 1, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 30), 
                TakerScore = 567, TwentyOne = true, Excuse = false, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.Unknown, GameId = 8UL});
        
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 24UL, Number = 1, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 567, TwentyOne = false, Excuse = false, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.Unknown, GameId = 9UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 25UL, Number = 2, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 25), 
                TakerScore = 567, TwentyOne = false, Excuse = true, Petit = PetitResultDB.LostAuBout, 
                Chelem = ChelemDB.AnnouncedSuccess, GameId = 9UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 26UL, Number = 3, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 27), 
                TakerScore = 567, TwentyOne = true, Excuse = true, Petit = PetitResultDB.Owned, 
                Chelem = ChelemDB.Success, GameId = 9UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 27UL, Number = 4, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 29), 
                TakerScore = 567, TwentyOne = true, Excuse = false, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.Unknown, GameId = 9UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 28UL, Number = 5, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 30), 
                TakerScore = 567, TwentyOne = false, Excuse = false, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.AnnouncedSuccess, GameId = 9UL});
        
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 29UL, Number = 1, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 21), 
                TakerScore = 567, TwentyOne = false, Excuse = true, Petit = PetitResultDB.LostAuBout, 
                Chelem = ChelemDB.Unknown, GameId = 10UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 30UL, Number = 2, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 25), 
                TakerScore = 567, TwentyOne = true, Excuse = false, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.AnnouncedSuccess, GameId = 10UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 31UL, Number = 3, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 29), 
                TakerScore = 567, TwentyOne = true, Excuse = true, Petit = PetitResultDB.Owned, 
                Chelem = ChelemDB.Success, GameId = 10UL});
        modelBuilder.Entity<HandEntity>().HasData(
            new {Id = 32UL, Number = 4, Rules = "FrenchTarotRules", Date = new DateTime(2022, 09, 30), 
                TakerScore = 567, TwentyOne = true, Excuse = false, Petit = PetitResultDB.Lost, 
                Chelem = ChelemDB.Unknown, GameId = 10UL});
        
        AddBiddings(modelBuilder);
    }

    private void AddBiddings(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Petite, Poignee = PoigneeDB.None, HandId = 1UL, PlayerId = 1UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 1UL, PlayerId = 2UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 1UL, PlayerId = 3UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Petite, Poignee = PoigneeDB.Simple, HandId = 2UL, PlayerId = 1UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 2UL, PlayerId = 2UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 2UL, PlayerId = 3UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Garde, Poignee = PoigneeDB.Simple, HandId = 3UL, PlayerId = 1UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 3UL, PlayerId = 2UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.Simple, HandId = 3UL, PlayerId = 3UL});


            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeSansLeChien, Poignee = PoigneeDB.None, HandId = 4UL, PlayerId = 2UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 4UL, PlayerId = 3UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 4UL, PlayerId = 4UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeContreLeChien, Poignee = PoigneeDB.None, HandId = 5UL, PlayerId = 2UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.Double, HandId = 5UL, PlayerId = 3UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 5UL, PlayerId = 4UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Petite, Poignee = PoigneeDB.None, HandId = 6UL, PlayerId = 2UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 6UL, PlayerId = 3UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.Triple, HandId = 6UL, PlayerId = 4UL});


            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeSansLeChien, Poignee = PoigneeDB.None, HandId = 7UL, PlayerId = 3UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 7UL, PlayerId = 4UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 7UL, PlayerId = 5UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeContreLeChien, Poignee = PoigneeDB.Triple, HandId = 8UL, PlayerId = 3UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 8UL, PlayerId = 4UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 8UL, PlayerId = 5UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Petite, Poignee = PoigneeDB.Triple, HandId = 9UL, PlayerId = 3UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 9UL, PlayerId = 4UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 9UL, PlayerId = 5UL});


            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeSansLeChien, Poignee = PoigneeDB.None, HandId = 10UL, PlayerId = 4UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 10UL, PlayerId = 5UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 10UL, PlayerId = 6UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 10UL, PlayerId = 7UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeContreLeChien, Poignee = PoigneeDB.None, HandId = 11UL, PlayerId = 4UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.Simple, HandId = 11UL, PlayerId = 5UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 11UL, PlayerId = 6UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 11UL, PlayerId = 7UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Petite, Poignee = PoigneeDB.Triple, HandId = 12UL, PlayerId = 4UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 12UL, PlayerId = 5UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 12UL, PlayerId = 6UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 12UL, PlayerId = 7UL});


            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeSansLeChien, Poignee = PoigneeDB.None, HandId = 13UL, PlayerId = 5UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 13UL, PlayerId = 6UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 13UL, PlayerId = 7UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 13UL, PlayerId = 8UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeContreLeChien, Poignee = PoigneeDB.None, HandId = 14UL, PlayerId = 5UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 14UL, PlayerId = 6UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 14UL, PlayerId = 7UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 14UL, PlayerId = 8UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Petite, Poignee = PoigneeDB.None, HandId = 15UL, PlayerId = 5UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 15UL, PlayerId = 6UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 15UL, PlayerId = 7UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 15UL, PlayerId = 8UL});


            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeSansLeChien, Poignee = PoigneeDB.Simple, HandId = 16UL, PlayerId = 6UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 16UL, PlayerId = 7UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 16UL, PlayerId = 8UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 16UL, PlayerId = 9UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeContreLeChien, Poignee = PoigneeDB.None, HandId = 17UL, PlayerId = 6UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 17UL, PlayerId = 7UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 17UL, PlayerId = 8UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 17UL, PlayerId = 9UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Petite, Poignee = PoigneeDB.None, HandId = 18UL, PlayerId = 6UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.Triple, HandId = 18UL, PlayerId = 7UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 18UL, PlayerId = 8UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 18UL, PlayerId = 9UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeSansLeChien, Poignee = PoigneeDB.None, HandId = 19UL, PlayerId = 6UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 19UL, PlayerId = 7UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.Simple, HandId = 19UL, PlayerId = 8UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 19UL, PlayerId = 9UL});


            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeSansLeChien, Poignee = PoigneeDB.None, HandId = 20UL, PlayerId = 7UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 20UL, PlayerId = 8UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 20UL, PlayerId = 9UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 20UL, PlayerId = 10UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.King, Poignee = PoigneeDB.None, HandId = 20UL, PlayerId = 11UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeSansLeChien, Poignee = PoigneeDB.None, HandId = 21UL, PlayerId = 7UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 21UL, PlayerId = 8UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 21UL, PlayerId = 9UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 21UL, PlayerId = 10UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.King, Poignee = PoigneeDB.None, HandId = 21UL, PlayerId = 11UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Garde, Poignee = PoigneeDB.Simple, HandId = 22UL, PlayerId = 7UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 22UL, PlayerId = 8UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 22UL, PlayerId = 9UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 22UL, PlayerId = 10UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.King, Poignee = PoigneeDB.None, HandId = 22UL, PlayerId = 11UL});


            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Petite, Poignee = PoigneeDB.None, HandId = 23UL, PlayerId = 8UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 23UL, PlayerId = 9UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 23UL, PlayerId = 10UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 23UL, PlayerId = 11UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.King, Poignee = PoigneeDB.None, HandId = 23UL, PlayerId = 12UL});


            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeSansLeChien, Poignee = PoigneeDB.None, HandId = 24UL, PlayerId = 9UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 24UL, PlayerId = 10UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 24UL, PlayerId = 11UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 24UL, PlayerId = 12UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.King, Poignee = PoigneeDB.None, HandId = 24UL, PlayerId = 13UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Garde, Poignee = PoigneeDB.None, HandId = 25UL, PlayerId = 9UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.Triple, HandId = 25UL, PlayerId = 10UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 25UL, PlayerId = 11UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 25UL, PlayerId = 12UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.King, Poignee = PoigneeDB.None, HandId = 25UL, PlayerId = 13UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeSansLeChien, Poignee = PoigneeDB.None, HandId = 26UL, PlayerId = 9UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 26UL, PlayerId = 10UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 26UL, PlayerId = 11UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 26UL, PlayerId = 12UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.King, Poignee = PoigneeDB.Simple, HandId = 26UL, PlayerId = 13UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Garde, Poignee = PoigneeDB.None, HandId = 27UL, PlayerId = 9UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.Double, HandId = 27UL, PlayerId = 10UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 27UL, PlayerId = 11UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 27UL, PlayerId = 12UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.King, Poignee = PoigneeDB.None, HandId = 27UL, PlayerId = 13UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.GardeSansLeChien, Poignee = PoigneeDB.None, HandId = 28UL, PlayerId = 9UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 28UL, PlayerId = 10UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.Triple, HandId = 28UL, PlayerId = 11UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 28UL, PlayerId = 12UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.King, Poignee = PoigneeDB.None, HandId = 28UL, PlayerId = 13UL});


            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Garde, Poignee = PoigneeDB.None, HandId = 29UL, PlayerId = 10UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 29UL, PlayerId = 11UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 29UL, PlayerId = 12UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 29UL, PlayerId = 13UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.King, Poignee = PoigneeDB.None, HandId = 29UL, PlayerId = 14UL});

            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Garde, Poignee = PoigneeDB.None, HandId = 30UL, PlayerId = 10UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 30UL, PlayerId = 11UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 30UL, PlayerId = 12UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 30UL, PlayerId = 13UL});
            modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
                    {Bidding = BiddingDB.King, Poignee = PoigneeDB.None, HandId = 30UL, PlayerId = 14UL});

        modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
            {Bidding = BiddingDB.Petite, Poignee = PoigneeDB.None, HandId = 31UL, PlayerId = 10UL});
        modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
            {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 31UL, PlayerId = 11UL});
        modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
            {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 31UL, PlayerId = 12UL});
        modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
            {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.Simple, HandId = 31UL, PlayerId = 13UL});
        modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
            {Bidding = BiddingDB.King, Poignee = PoigneeDB.None, HandId = 31UL, PlayerId = 14UL});

        modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
            {Bidding = BiddingDB.GardeContreLeChien, Poignee = PoigneeDB.Triple, HandId = 32UL, PlayerId = 10UL});
        modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
            {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 32UL, PlayerId = 11UL});
        modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
            {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 32UL, PlayerId = 12UL});
        modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
            {Bidding = BiddingDB.Opponent, Poignee = PoigneeDB.None, HandId = 32UL, PlayerId = 13UL});
        modelBuilder.Entity<BiddingPoigneeEntity>().HasData(new BiddingPoigneeEntity
            {Bidding = BiddingDB.King, Poignee = PoigneeDB.None, HandId = 32UL, PlayerId = 14UL});
    }
}