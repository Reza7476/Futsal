using Futsal.Services.Players.Contracts.DTOs;

namespace Futsal.Services.Players.Contracts;
public interface PlayerServices
{
    Task Add(AddPlayerDto command);
    Task Edit(int id, EditPlayerDto command);
    Task Delete(int id);


    Task<List<PlayerDto>?> GetByAgeFilter(FilterAgePlayerDto query);
    Task AddPlayerToAteam(int id, int teamId);
}
