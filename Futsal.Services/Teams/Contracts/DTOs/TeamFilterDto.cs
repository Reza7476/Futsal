using Futsal.Entities.Teams;

namespace Futsal.Services.Teams.Contracts.DTOs;

public class TeamFilterDto
{
    public string?  Name { get; set; }
    public ColorDress? ColorDress { get; set; }
}
