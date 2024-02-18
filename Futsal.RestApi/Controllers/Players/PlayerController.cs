using Futsal.Services.Players.Contracts;
using Futsal.Services.Players.Contracts.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Futsal.RestApi.Controllers.Players;
[Route("api/players")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly PlayerServices _plyareService;

    public PlayerController(PlayerServices plyareService)
    {
        _plyareService = plyareService;
    }
    [HttpPost]
    public async Task Add(AddPlayerDto comman)
    {
        await _plyareService.Add(comman);
    }
    [HttpPatch("{id}")]
    public async Task Edit([FromRoute] int id, EditPlayerDto command)
    {

        await _plyareService.Edit(id, command);
    }
    [HttpDelete("{id}")]
    public async Task Delete([FromRoute]int id)
    {
        await _plyareService.Delete(id);
    }
    [HttpGet]
    public async Task <List<PlayerDto>?> GetByAgeFilter([FromQuery]FilterAgePlayerDto command)
    {
        return await _plyareService.GetByAgeFilter(command);
    }
    [HttpPatch]
    public async Task MentionPlayerToATeam(AddPlayerToTeamDto command)
    {
        await _plyareService.AddPlayerToAteam(command);
    }
}
