using Futsal.Entities.Players;
using Futsal.Services.Players.Contracts;
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

    public async Task<bool> ExistPlayerForEdit(string curreName, string newName)
    {
       return  await _db.Players.AnyAsync(p=>p.Name!=curreName&&p.Name==newName);
    }

    public async Task<List<Player>> GetAll()
    {
      return await _db.Players.ToListAsync();
    }

    public async Task<List<Player>?> GetTeamPlayersByFilter(Expression<Func<Player, bool>> where)
    {
        return await _db.Players
            .Include(x=>x.Team)
            .Where(where)
            .ToListAsync();
    }
}
