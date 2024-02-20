using Futsal.Services.Players.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futsal.Services.Players.Contracts;
public  interface PlayerServices
{
    Task Add(AddPlayerDto command);
    Task Edit(int id,EditPlayerDto command);
    Task Delete(int id);


    Task<List<PlayerDto>?> GetByAgeFilter(FilterAgePlayerDto command);
    Task AddPlayerToAteam(AddPlayerToTeamDto command);
}
