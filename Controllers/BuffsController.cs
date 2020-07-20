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
  public class BuffsController : ControllerBase {
    private readonly ILogger<BuffsController> _logger;
    private readonly PlanarContext _db;

    public BuffsController(ILogger<BuffsController> logger, PlanarContext ctx) {
      _logger = logger;
      _db = ctx;
    }

    [HttpGet("{id}")]
    public async Task<Plane> GetBuffsForPlane(int id) =>
      await _db.planes.Include(x => x.buffs).FirstOrDefaultAsync(x => x.id == id);

    [HttpPost("{id}")]
    public async Task<ActionResult> SaveBuffs(int id, [FromBody] Plane p) {
      var plane = await _db.planes.Include(x => x.buffs).FirstOrDefaultAsync(x => x.id == id);

      plane.buffs = p.buffs;

      _db.Entry(plane).State = EntityState.Modified;

      await _db.SaveChangesAsync();

      return Ok();
    }
  }
}