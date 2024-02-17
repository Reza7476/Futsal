using Futsal.Entities.Teams;

namespace Futsal.Entities.Players;
public class Player
{

    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public PlayerRole Role { get; set; }
    public int? TeamId { get; set; }
    public Team Team { get; set; }

}


public enum PlayerRole
{
    KeepGoler=1,
    Forward=2,
    Defense=3,
}