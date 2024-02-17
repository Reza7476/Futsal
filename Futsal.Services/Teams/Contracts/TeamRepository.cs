using Futsal.Entities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Futsal.Services.Teams.Contracts;
public interface TeamRepository
{

    void Add(Team team);


    void Edit(Team team);
    void Delete(Team team);


    Task<List<Team>?> GetByFilter(Expression<Func<Team, bool>> where);

    Task<List<Team>> GetAll();

    Task <Team?> GetById(int id);    


    Task<bool> IsTeamExist(string name);
    Task<bool> ExistTeamForEdit(string currentName, string newName);
}
