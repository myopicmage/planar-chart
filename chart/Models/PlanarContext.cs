#nullable disable

using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Azure.Services.AppAuthentication;

namespace planar.server.Models {
  public class PlanarContext : DbContext {
    public DbSet<Buff> buffs { get; set; }
    public DbSet<Character> characters { get; set; }
    public DbSet<Location> locations { get; set; }
    public DbSet<Plane> planes { get; set; }
    public DbSet<Quest> quests { get; set; }

    public PlanarContext(DbContextOptions<PlanarContext> options) : base(options) {
      var conn = (SqlConnection)Database.GetDbConnection();
      conn.AccessToken = (new AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/").Result;
    }
  }
}