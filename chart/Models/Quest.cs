namespace planar.server.Models {
  public class Quest : Common {
    public string name { get; set; } = "";
    public string description { get; set; } = "";
    public string reward { get; set; } = "";
    public virtual Character? giver { get; set; }
    public QuestStatus status { get; set; }
  }

  public enum QuestStatus {
    ToDo,
    InProgress,
    Complete,
    Abandoned
  }
}