using Futsal.Entities.Teams;
using Futsal.Services.Teams.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futsal.Services.Teams.Contracts;
public interface TeamServices
{

    Task Add(AddTeamDto command);
    Task Edit(int id,EditTeamDto command);
    Task Delete(int id);
    Task<List<TeamDto>?> GetByFilter(TeamFilterDto command);

}
