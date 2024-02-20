using Futsal.Entities.Teams;
using Futsal.Services.Teams.Contracts;
using Futsal.Services.Teams.Contracts.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Futsal.Persistence.EF.Teams;
public class EFTeamRepository : TeamRepository
{
    private readonly EFDatabaseContext _db;
    public EFTeamRepository(EFDatabaseContext db)
    {
        _db = db;
    }

    public void Add(Team team)
    {
        _db.Teams.Add(team);
    }

    public void Delete(Team team)
    {
        _db.Teams.Remove(team);
    }

    public void Edit(Team team)
    {
        _db.Teams.Update(team);
    }


    public async Task<bool> ExistTeamExceptItsSelf(int id, string Name)
    {
        return await _db.Teams.AnyAsync(t => t.Id != id && t.Name == Name);
    }

    //public async Task<List<TeamDto>> GetAll()
    //{
    //    var teams = await _db.Teams
    //       .Include(t => t.Players)
          
    //       .Select(_ => new TeamDto()
    //       {
    //           Id = _.Id,
    //           Name = _.Name,
    //           ColorDressOrigin = _.ColorDressNormal,
    //           ColorDressNormal = _.ColorDressOrigin
    //       }).ToListAsync();
    //    return teams;



    //}

    public async Task<List<TeamDto>?> Get(Expression<Func<Team, bool>> where)
    {
        var teams = await _db.Teams
            .Include(t => t.Players)
            .Where(where)
            .Select(_ => new TeamDto()
            {
                Id = _.Id,
                Name = _.Name,
                ColorDressOrigin = _.ColorDressNormal,
                ColorDressNormal = _.ColorDressOrigin
            }).ToListAsync();
        return teams;

    }


    //public async Task<List<TeamDto>?> GetByFilter(Expression<Func<Team, bool>> where)
    //{
    //    var teams = await _db.Teams
    //        .Include(t => t.Players)
    //        .Where(where)
    //        .Select(_ => new TeamDto()
    //        {
    //            Id = _.Id,
    //            Name = _.Name,
    //            ColorDressOrigin = _.ColorDressNormal,
    //            ColorDressNormal = _.ColorDressOrigin
    //        }).ToListAsync();
    //    return teams;

    //}

    public async Task<Team?> GetById(int id)
    {
        return await _db.Teams
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> IsTeamExist(string name)
    {
        return await _db.Teams.AnyAsync(x => x.Name == name);
    }
}
