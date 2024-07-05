namespace SenD.Models;

public class Monster : RepoItem<int>
{
  public string Name { get; set; }
  public string Img { get; set; }
  public string Type { get; set; }
  public string SubType { get; set; }
  public int Power { get; set; }
  public int Toughness { get; set; }
  public string Description { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }

}