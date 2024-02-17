using Futsal.Entities.Players;
using Futsal.Entities.Teams;
using Microsoft.EntityFrameworkCore;

namespace Futsal.Persistence.EF;
public class EFDatabaseContext : DbContext
{


    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-9PR0IFL;Database=FutsalManagment;Trusted_Connection=true;TrustServerCertificate=true");
        base.OnConfiguring(optionsBuilder);
    }
}
