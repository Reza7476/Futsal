using Futsal.Entities.Teams;
using Futsal.Services.Teams.Contracts;
using Futsal.Services.Teams.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Taav.Contarcts;

namespace Futsal.Services.Teams;
public class TeamAppServices : TeamServices
{

    private readonly UnitOfWork _unitOfWork;
    private readonly TeamRepository _teamRepository;

    public TeamAppServices(UnitOfWork unitOfWork,
        TeamRepository teamRepository)
    {
        _unitOfWork = unitOfWork;
        _teamRepository = teamRepository;
    }

    public async Task Add(AddTeamDto command)
    {
        var teamExist = await _teamRepository.IsTeamExist(command.Name);
        if (teamExist == true)
        {
            throw new Exception("team already has been existed");
        }
        if (command.ColorDressOrigin == command.ColorDressNormal)
        {
            throw new Exception("colore of Normal and originDress is repeted ");
        }
        var newTeam = new Team()
        {
            Name = command.Name,
            ColorDressNormal = command.ColorDressNormal,
            ColorDressOrigin = command.ColorDressOrigin,

        };
        _teamRepository.Add(newTeam);
        await _unitOfWork.Complete();




    }

    public async Task Delete(int id)
    {
        var team = await _teamRepository.GetById(id);
        if (team == null)
            throw new Exception("team not found");

        _teamRepository.Delete(team);

        await _unitOfWork.Complete();
    }

    public async Task Edit(int id, EditTeamDto command)
    {
        var team = await _teamRepository.GetById(id);
        if (team == null)
            throw new Exception("team not found");

        var checkName = await _teamRepository.ExistTeamForEdit(team.Name,command.Name);
        if (checkName == true)
            throw new Exception("this sname exist ");

        if (command.ColorDressOrigin == command.ColorDressNormal)

            throw new Exception("colore of Normal and originDress is repeted ");

        team.Name = command.Name;
        team.ColorDressNormal = command.ColorDressNormal;
        team.ColorDressOrigin = command.ColorDressOrigin;
        _teamRepository.Edit(team);
        await _unitOfWork.Complete();



    }

    public async Task<List<TeamDto>?> GetByFilter(TeamFilterDto command)
    {
        var teams = await _teamRepository
             .GetByFilter(t => (t.Name == command.Name || command.Name == null)
             && (t.ColorDressOrigin == command.ColorDress || command.ColorDress == null)
             || (t.ColorDressNormal == command.ColorDress || command.ColorDress == null));
        List<TeamDto> teamDtos = new();

        if (teams.Count > 0)
        {
            foreach (var team in teams)
            {
                TeamDto teamDto = new TeamDto()
                {
                    Name=team.Name,
                    ColorDressNormal=team.ColorDressNormal,
                    ColorDressOrigin=team.ColorDressOrigin,
                     Id=team.Id,

                };
                teamDtos.Add(teamDto);  
            }
        }
        return teamDtos;



    }
}
