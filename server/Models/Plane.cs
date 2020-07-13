using System.Collections.Generic;

namespace planar.server.Models {
    public class Plane : Common {
        public string name { get; set; }
        public string description { get; set; }
        public Ring ring { get; set; }
        public virtual IEnumerable<Buff> buffs { get; set; } = new List<Buff>();
    }

    public enum Ring {
        Center,
        Echoes,
        Chaos,
        WildReaches
    }
}