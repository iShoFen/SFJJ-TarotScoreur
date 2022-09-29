using Microsoft.EntityFrameworkCore;

namespace TarotDB;

internal class TarotDBContext : DbContext
{
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=TarotScoreur.db");
}