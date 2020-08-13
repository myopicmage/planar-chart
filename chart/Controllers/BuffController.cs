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
  public class BuffController : ControllerBase {
    private readonly ILogger<BuffController> _logger;
    private readonly PlanarContext _db;
    private readonly IHubContext<UpdateHub> _hubCtx;

    public BuffController(ILogger<BuffController> logger, PlanarContext ctx, IHubContext<UpdateHub> hubCtx) {
      _logger = logger;
      _db = ctx;
      _hubCtx = hubCtx;
    }

    [HttpPost]
    public async Task<IActionResult> AddBuff([FromBody] Buff b) {
      if (!ModelState.IsValid) {
        return BadRequest();
      }

      try {
        _db.buffs.Add(b);

        await _db.SaveChangesAsync();

        return Ok();
      } catch {
        return BadRequest();
      }
    }

    public async Task<IEnumerable<Buff>> UpsertBuffs(IEnumerable<Buff> buffs) {
      var list = buffs.ToList();

      foreach (var buff in list) {
        if (buff.id == 0) {
          _db.buffs.Add(buff);
        } else {
          _db.buffs.Update(buff);
        }
      }

      try {
        await _db.SaveChangesAsync();

        return buffs;
      } catch {
        return new List<Buff>();
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBuff(int id) {
      if (id == 0) {
        return BadRequest();
      }

      var buff = await _db.buffs.SingleOrDefaultAsync(x => x.id == id);

      try {
        _db.buffs.Remove(buff);

        await _db.SaveChangesAsync();

        return Ok();
      } catch {
        return BadRequest();
      }
    }
  }
}