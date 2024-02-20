using Futsal.Entities.Players;
using Futsal.Services.Players.Contracts.DTOs;
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

    Task<bool> ExistPlayerExceptItsSelf(int id, string name);
 
    
    Task<bool> IsExist(string name);

    Task<bool> HasPlayerATeam(int id);
    Task<Player?> GetById(int id);
    Task<List<PlayerDto>?> Get(FilterAgePlayerDto query);
    Task<List<Player>>GetBySpecification(Expression<Func<Player, bool>> where); 
}
