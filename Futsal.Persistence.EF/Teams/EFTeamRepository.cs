using Futsal.Entities.Teams;
using Futsal.Services.Teams.Contracts;
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

    public async Task<bool> ExistTeamForEdit(string currentName, string newName)
    {
       return await _db.Teams.AnyAsync(t=>t.Name!=currentName && t.Name==newName);
    }

    public async Task<List<Team>> GetAll()
    {
       return await _db.Teams.Include(x=>x.Players).ToListAsync();
    }

    public async Task<List<Team>?> GetByFilter(Expression<Func<Team, bool>> where)
    {
        return await _db.Teams
            //.Include(x => x.Players)
            .Where(where).ToListAsync();
       
    }

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
