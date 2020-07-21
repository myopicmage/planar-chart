using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using planar.server.Hubs;
using planar.server.Models;

namespace planar.server {
  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.AddDbContext<PlanarContext>(opt =>
        opt.UseSqlite(Configuration.GetConnectionString("planes"))
      );

      services.AddDefaultIdentity<IdentityUser>(opt =>
        opt.SignIn.RequireConfirmedAccount = true
      ).AddEntityFrameworkStores<PlanarContext>();

      services.AddRazorPages();

      services.AddControllersWithViews();

      services.AddSignalR();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapHub<UpdateHub>("/updates");
        endpoints.MapRazorPages();
        endpoints.MapControllers();
      });

      app.UseStaticFiles();
    }
  }
}
