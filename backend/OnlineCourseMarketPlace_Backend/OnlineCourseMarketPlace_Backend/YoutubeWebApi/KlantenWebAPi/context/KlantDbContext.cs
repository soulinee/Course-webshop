using KlantenWebAPi.model;
using Microsoft.EntityFrameworkCore;

namespace KlantenWebAPi.context;

public class KlantDbContext : DbContext
{
    public DbSet<Klant> Klanten => Set<Klant>();

    public KlantDbContext(DbContextOptions<KlantDbContext> options)
        : base(options)
    {
    }
}
