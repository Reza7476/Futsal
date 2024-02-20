using Futsal.Services.Teams.Contracts;
using Futsal.Services.Teams.Contracts.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Futsal.RestApi.Controllers.Teams;
[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{
    private readonly TeamServices _teamService;

    public TeamController(TeamServices service)
    {
        _teamService = service;
    }
    [HttpPost]
    public async Task Add(AddTeamDto command)
    {
        await _teamService.Add(command);
    }
    [HttpPatch("{id}")]
    public async Task Edit([FromRoute]int id,EditTeamDto command)
    {
        await _teamService.Edit(id,command);
    }

    [HttpDelete("{id}")]
    public async  Task Delete([FromRoute]int id)
    {
        await _teamService.Delete(id);
    }
    [HttpGet]
    public async Task <List<TeamDto>?> GetByFilter([FromQuery]TeamFilterDto command)
    {
        return await _teamService.GetByFilter(command);
    }

}
