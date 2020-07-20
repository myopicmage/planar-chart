using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace planar.server.Models {
  public class PlanarContext : IdentityDbContext {
    public DbSet<Buff> buffs { get; set; }
    public DbSet<Character> characters { get; set; }
    public DbSet<Location> locations { get; set; }
    public DbSet<Plane> planes { get; set; }
    public DbSet<Quest> quests { get; set; }

    public PlanarContext(DbContextOptions<PlanarContext> options)
      : base(options) { }
  }
}