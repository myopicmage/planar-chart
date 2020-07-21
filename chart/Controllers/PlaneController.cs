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
      await _db.planes.Include(x => x.buffs).ToArrayAsync();

    [HttpGet("{id}")]
    public async Task<Plane> GetPlane(int id) =>
      await _db.planes.Include(x => x.buffs).FirstOrDefaultAsync(x => x.id == id);

    [HttpPost("{id}")]
    public async Task<ActionResult> UpdatePlane(int id, [FromBody] Plane p) {
      var plane = await _db.planes.FirstOrDefaultAsync(x => x.id == id);

      if (plane is null) {
        return NotFound();
      }

      if (!ModelState.IsValid) {
        return BadRequest();
      }

      plane.name = p.name;
      plane.description = p.description;
      plane.ring = p.ring;
      plane.revealed = p.revealed;
      plane.locked = p.locked;

      try {
        await _db.SaveChangesAsync();

        return Ok();
      } catch (Exception ex) {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddPlane([FromBody] Plane p) {
      if (ModelState.IsValid) {
        await _db.planes.AddAsync(p);

        await _db.SaveChangesAsync();

        return Ok();
      } else {
        return BadRequest();
      }
    }
  }
}