using Futsal.Entities.Players;
using Futsal.Services.Players.Contracts;
using Futsal.Services.Players.Contracts.DTOs;
using Futsal.Services.Players.Exceptions;
using Futsal.Services.Teams.Contracts;
using Futsal.Services.Teams.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Taav.Contarcts.Interfaces;

namespace Futsal.Services.Players;
public class PlayerAppService : PlayerServices
{
    private readonly TeamRepository _teamRepository;


    private readonly PlayerRepository _playerRepository;
    private readonly UnitOfWork _unitOfWork;
    public PlayerAppService(PlayerRepository playerRepository,
        UnitOfWork unitOfWork,
        TeamRepository teamRepository)
    {
        this._playerRepository = playerRepository;
        _unitOfWork = unitOfWork;
        _teamRepository = teamRepository;
    }

    public async Task Add(AddPlayerDto command)
    {
        var player = await _playerRepository.IsExist(command.Name);
        if (player == true)
            throw new PlayerIsExist();

        var newPlayer = new Player()
        {
            Name = command.Name,
            BirthDate = command.BirthDate,
            Role = command.PlayerRole,
        };

        _playerRepository.Add(newPlayer);
        await _unitOfWork.Complete();


    }

    public async Task Delete(int id)
    {
        var player = await _playerRepository.GetById(id);
        if (player == null)
            throw new PlayerNotFound();

        _playerRepository.Delete(player);
        await _unitOfWork.Complete();
    }

    public async Task Edit(int id, EditPlayerDto command)
    {
        var player = await _playerRepository.GetById(id);
        if (player == null)
            throw new PlayerNotFound();
        var checkName = await _playerRepository.ExistPlayerExceptItsSelf(id, command.Name);
        if (checkName == true)
            throw new PlayerIsExist();
        player.Name = command.Name;
        player.BirthDate = command.BirthDate;
        player.Role = command.PlayerRole;
        _playerRepository.Edit(player);
        await _unitOfWork.Complete();

    }

    public async Task<List<PlayerDto>?> GetByAgeFilter(FilterAgePlayerDto query)
    {
        var players = await _playerRepository.Get(query);
        return players;
    }

    public async Task AddPlayerToAteam(int playerId, int teamId)
    {
        var team = await _teamRepository.GetById(teamId);
        if (team == null)
            throw new TeamNotFound();
        var player = await _playerRepository.GetById(playerId);
        if (player == null)
            throw new PlayerNotFound();

        var checkPlayerHasTeam = await _playerRepository.HasPlayerATeam(playerId);
        if (checkPlayerHasTeam == true)
            throw new PlayerHasTeam();

        var teamPlayers = await _playerRepository.GetBySpecification(x => x.TeamId == teamId);
        if (teamPlayers.Count() >= 5)
            throw new TeamCloesd();
        var keepGolerIsExist = teamPlayers.Any(x => x.Role == PlayerRole.KeepGoler);

        var plyerIsExist = teamPlayers.Any(x => x.TeamId == teamId);
        if (teamPlayers.Count() < 4)
        {
            if (keepGolerIsExist == true && player.Role == PlayerRole.KeepGoler)
                throw new TeamHasGolKeeper();
            player.TeamId = team.Id;
            await _unitOfWork.Complete();
        }
        else
        {
            if (keepGolerIsExist == false && player.Role != PlayerRole.KeepGoler)
                throw new TeamNeedsKeepGoler();
            player.TeamId = team.Id;
            await _unitOfWork.Complete();

        }




    }

}
