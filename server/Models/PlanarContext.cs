using Microsoft.EntityFrameworkCore;

namespace planar.server.Models {
    public class PlanarContext : DbContext {
        public DbSet<Buff> buffs { get; set; }
        public DbSet<Character> characters { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Plane> planes { get; set; }
        public DbSet<Quest> quests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=planes.db");
    }
}