using Futsal.Entities.Teams;
using Futsal.Services.Teams.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taav.Contarcts.Interfaces;

namespace Futsal.Services.Teams.Contracts;
public interface TeamRepository:Repository
{

    void Add(Team team);
    void Edit(Team team);
    void Delete(Team team);


    Task <Team?> GetById(int id);    
    Task<List<TeamDto>?> Get(Expression<Func<Team, bool>> where);
    Task<bool> IsTeamExist(string name);
    Task<bool> ExistTeamExceptItsSelf(int id, string Name);

}
