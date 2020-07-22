using Microsoft.AspNetCore.SignalR;
using planar.server.Models;
using System.Threading.Tasks;

namespace planar.server.Hubs {
  public class UpdateHub : Hub {
    public async Task SendMessage(string user, string message) {
      await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task Ping(int planeId) {
      await Clients.All.SendAsync("pong", planeId);
    }

    public async Task UpdatePlane(Plane p) {
      await Clients.All.SendAsync("UpdatePlane", p);
    }
  }
}