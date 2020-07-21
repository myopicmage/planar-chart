using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using planar.server.Models;

namespace planar.server.Controllers {
  [Route("[controller]")]
  public class AdminController : Controller {
    private readonly ILogger<AdminController> _logger;
    private readonly PlanarContext _db;

    public AdminController(ILogger<AdminController> logger, PlanarContext ctx) {
      _logger = logger;
      _db = ctx;
    }

    public ActionResult Index() => View();
  }
}