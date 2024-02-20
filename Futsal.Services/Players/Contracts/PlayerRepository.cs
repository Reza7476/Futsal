using Futsal.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Futsal.Services.Players.Contracts;
public interface PlayerRepository
{

    void Add(Player player);
    void Edit(Player player); 
    void Delete(Player player);

    Task<bool> ExistPlayerForEdit(string curreName, string newName);
    Task<bool> IsExist(string name);
    Task<Player?> GetById(int id);
    Task<List<Player>> GetAll();

    Task<List<Player>?> GetTeamPlayersByFilter(Expression<Func<Player, bool>> where);  
}
