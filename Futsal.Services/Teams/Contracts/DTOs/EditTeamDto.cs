using Futsal.Entities.Teams;

namespace Futsal.Services.Teams.Contracts.DTOs;

public class EditTeamDto
{

    public string Name { get; set; }
    public ColorDress ColorDressOrigin { get; set; }
    public ColorDress ColorDressNormal { get; set; }
}
