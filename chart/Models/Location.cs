using System.Collections.Generic;

namespace planar.server.Models {
  public class Location : Common {
    public long PlaneId { get; set; }
    public string name { get; set; } = "";
    public string description { get; set; } = "";

    public virtual IEnumerable<Buff> buffs { get; set; } = new List<Buff>();
    public virtual IEnumerable<Character> characters { get; set; } = new List<Character>();
    public virtual IEnumerable<Quest> quests { get; set; } = new List<Quest>();
  }
}