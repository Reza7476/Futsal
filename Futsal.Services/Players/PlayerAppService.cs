using Futsal.Entities.Players;
using Futsal.Services.Players.Contracts;
using Futsal.Services.Players.Contracts.DTOs;
using Futsal.Services.Teams.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Taav.Contarcts;

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
            throw new Exception("player is exist");

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
            throw new Exception("player not found");

        _playerRepository.Delete(player);
        await _unitOfWork.Complete();
    }

    public async Task Edit(int id, EditPlayerDto command)
    {
        var player = await _playerRepository.GetById(id);
        if (player == null)
            throw new Exception("player not found");


        var checkName = await _playerRepository.ExistPlayerForEdit(player.Name, command.Name);
        if (checkName == true) throw new Exception("player is exist");
        player.Name = command.Name;
        player.BirthDate = command.BirthDate;
        player.Role = command.PlayerRole;
        _playerRepository.Edit(player);
        await _unitOfWork.Complete();

    }

    public async Task<List<PlayerDto>?> GetByAgeFilter(FilterAgePlayerDto command)
    {
        var players = await _playerRepository.GetAll();



        List<PlayerDto> playerDtos = new();
        foreach (var player in players)
        {

            var age = Age(player.BirthDate);
            if (age >= command.StartAge && age < command.EndAge)
            {
                PlayerDto playerDto = new PlayerDto()
                {
                    Id = player.Id,
                    Name = player.Name,
                    BirthDate = player.BirthDate,
                    PlayerRole = player.Role
                };
                playerDtos.Add(playerDto);

            }

        }

        return playerDtos;
    }




    public int Age(DateTime playerBirth)
    {
        TimeSpan a = DateTime.Now - playerBirth;
        int age = (int)(a.TotalDays) / 365;
        return age;
    }

    public async Task AddPlayerToAteam(AddPlayerToTeamDto command)
    {
        var team = await _teamRepository.GetById(command.TeamId);

        if (team == null)
            throw new Exception("team not found");

        var player = await _playerRepository.GetById(command.PlayerId);

        if (player == null)

            throw new Exception("player not found");
        var teamPlayers = await _playerRepository.GetTeamPlayersByFilter(x => x.TeamId == command.TeamId);


        if (teamPlayers.Count() >= 5)
            throw new Exception("team closed");

        if (player.Role == PlayerRole.KeepGoler)
        {
            if (teamPlayers.Where(x => x.Role == PlayerRole.KeepGoler).Count() >= 1)
                throw new Exception("team has keepGoler");
            player.TeamId = command.TeamId;
        }
        player.TeamId = command.TeamId;

        await _unitOfWork.Complete();


    }
}
