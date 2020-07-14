using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using planar.server.Models;

namespace planar.server.Controllers {
  [Route("")]
  public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;
    private readonly PlanarContext _db;

    public HomeController(ILogger<HomeController> logger, PlanarContext ctx) {
      _logger = logger;
      _db = ctx;
    }

    public ActionResult Index() => View();
  }
}