using Futsal.Services.Players.Contracts.DTOs;
using Taav.Contarcts.Interfaces;

namespace Futsal.Services.Players.Contracts;
public interface PlayerServices:Service
{
    Task Add(AddPlayerDto command);
    Task Edit(int id, EditPlayerDto command);
    Task Delete(int id);


    Task<List<PlayerDto>?> GetByAgeFilter(FilterAgePlayerDto query);
    Task AddPlayerToAteam(int id, int teamId);
}
