using Futsal.Entities.Players;
using Futsal.Entities.Teams;

namespace Futsal.Services.Teams.Contracts.DTOs;

public class TeamDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ColorDress ColorDressOrigin { get; set; }
    public ColorDress ColorDressNormal { get; set; }
}
