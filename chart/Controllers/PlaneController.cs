using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using planar.server.Hubs;
using planar.server.Models;

namespace planar.server.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class PlaneController : ControllerBase {
    private readonly ILogger<PlaneController> _logger;
    private readonly PlanarContext _db;
    private readonly IHubContext<UpdateHub> _hubCtx;

    public PlaneController(ILogger<PlaneController> logger, PlanarContext ctx, IHubContext<UpdateHub> hubCtx) {
      _logger = logger;
      _db = ctx;
      _hubCtx = hubCtx;
    }

    public async Task<IEnumerable<Plane>> GetPlanes() =>
      await _db.planes.Include(x => x.buffs).ToArrayAsync();

    [HttpGet("{id}")]
    public async Task<Plane> GetPlane(int id) =>
      await _db.planes.Include(x => x.buffs).FirstOrDefaultAsync(x => x.id == id);

    [HttpPost("{id}")]
    public async Task<ActionResult> UpdatePlane(int id, [FromBody] Plane p) {
      var plane = await _db.planes.Include(x => x.buffs).FirstOrDefaultAsync(x => x.id == id);

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
        plane.buffs = plane.buffs.ToList().Concat(await SaveBuffs(p.buffs.Where(x => x.id == 0).ToList()));

        await _db.SaveChangesAsync();

        await _hubCtx.Clients.All.SendAsync("UpdatePlane", plane);

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

    private async Task<IEnumerable<Buff>> SaveBuffs(IEnumerable<Buff> buffs) {
      foreach (var buff in buffs) {
        if (buff.id == 0) {
          _db.buffs.Add(buff);
        }
      }

      await _db.SaveChangesAsync();

      return buffs;
    }
  }
}