using System;

namespace planar.server.Models {
  public class Character : Common {
    public long LocationId { get; set; }
    public string name { get; set; } = "";
    public string race { get; set; } = "";
    public string description { get; set; } = "";
  }
}