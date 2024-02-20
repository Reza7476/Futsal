using Futsal.Entities.Players;
using Futsal.Services.Players.Contracts;
using Futsal.Services.Players.Contracts.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Futsal.Persistence.EF.Players;
public class EFPlayerRepository : PlayerRepository
{

    private readonly EFDatabaseContext _db;

    public EFPlayerRepository(EFDatabaseContext db)
    {
        _db = db;
    }

    public void Add(Player player)
    {
        _db.Players.Add(player);
    }

    public void Delete(Player player)
    {
        _db.Players.Remove(player);
    }

    public async Task<Player?> GetById(int id)
    {
        return await _db.Players.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> IsExist(string name)
    {
        return await _db.Players.AnyAsync(p => p.Name == name);
    }

    public void Edit(Player player)
    {
        _db.Players.Update(player);
    }

    public async Task<bool> ExistPlayerExceptItsSelf(int id, string name)
    {
        return await _db.Players.AnyAsync(p => p.Id != id && p.Name == name);
    }


    public async Task<List<PlayerDto>?> Get(FilterAgePlayerDto query)
    {
        var players = await _db.Players
        .Include(x => x.Team)
        .ToListAsync();
        List<PlayerDto> playerDtos = new();
        if (query.MaximumAge > 0 || query.MinimumAge > 0)
        {

            foreach (var player in players)
            {
                var age = ConvertAge(player.BirthDate);
                if ((age >= query.MinimumAge) && (age <= query.MaximumAge))
                {
                    PlayerDto playerDto = new PlayerDto()
                    {
                        Id = player.Id,
                        Name = player.Name,
                        PlayerRole = player.Role,
                        BirthDate = player.BirthDate,
                        TeamId = player.TeamId
                    };
                    if (player.TeamId != null)
                        playerDto.TeamName = player.Team.Name;
                    playerDtos.Add(playerDto);
                }

            }
        }
        else
        {
            foreach (var player in players)
            {
                PlayerDto playerDto = new PlayerDto()
                {
                    Id = player.Id,
                    Name = player.Name,
                    PlayerRole = player.Role,
                    BirthDate = player.BirthDate,
                    TeamId = player.TeamId
                };
                if (player.TeamId != null)
                    playerDto.TeamName = player.Team.Name;
                playerDtos.Add(playerDto);
            }
        }
        return playerDtos;
    }


    public async Task<List<Player>> GetBySpecification(Expression<Func<Player, bool>> where)
    {
        return await _db.Players
              .Where(where)
              .Include(x => x.Team)
              .ToListAsync();
    }

    public async Task<bool> HasPlayerATeam(int id)
    {
        return await _db.Players.AnyAsync(x => x.Id == id && x.Team != null);
    }
    public static int ConvertAge(DateTime birhtDate)
    {
        var days = (DateTime.UtcNow - birhtDate).Days;
        return (int)(days / 365.25);
    }
}

