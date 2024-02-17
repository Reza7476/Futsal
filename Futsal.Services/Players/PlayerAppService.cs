using Futsal.Entities.Players;
using Futsal.Services.Players.Contracts;
using Futsal.Services.Players.Contracts.DTOs;
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



    private readonly PlayerRepository _playerRepository;
    private readonly UnitOfWork _unitOfWork;
    public PlayerAppService(PlayerRepository playerRepository,
        UnitOfWork unitOfWork)
    {
        this._playerRepository = playerRepository;
        _unitOfWork = unitOfWork;
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

    public async Task<List<PlayerDto>> GetByFilter(int startAge, int endAge)
    {
        var players = await _playerRepository.GetAll();
        

        
    }




    public int Age(DateTime playerBirth)
    {
        int a = DateTime.Now.Day - playerBirth.Day;


        int age = a / 365;
        return age;
    }
}
