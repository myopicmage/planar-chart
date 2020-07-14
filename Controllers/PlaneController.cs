using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using planar.server.Models;

namespace planar.server.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class PlaneController : ControllerBase {
    private readonly ILogger<PlaneController> _logger;
    private readonly PlanarContext _db;

    public PlaneController(ILogger<PlaneController> logger, PlanarContext ctx) {
      _logger = logger;
      _db = ctx;
    }

    public async Task<IEnumerable<Plane>> GetPlanes() =>
      await _db.planes
        .ToArrayAsync();

    [Route("add")]
    public async Task<ActionResult> AddPlane() {
      var plane = new Plane {
        name = "The Feywild",
        description = "An echo of the Prime Material Plane, skewing toward the light. The home of the Fey. Be wary, all ye who seek to travel here.",
        ring = Ring.Echoes,
      };

      await _db.planes.AddAsync(plane);

      await _db.SaveChangesAsync();

      return RedirectToRoute(nameof(GetPlanes));
    }
  }
}