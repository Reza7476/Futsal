using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taav.Contarcts;

namespace Futsal.Persistence.EF;
public class EFUnitOfWork : UnitOfWork
{


    private readonly EFDatabaseContext _db;

    public EFUnitOfWork(EFDatabaseContext db)
    {
        _db = db;
    }

    public async Task Begin()
    {
        await _db.Database.BeginTransactionAsync();
    }

    public async Task Commit()
    {
        await _db.Database.CommitTransactionAsync();
    }

    public async Task Complete()
    {
        await _db.SaveChangesAsync();
    }

    public async Task RolleBack()
    {


        await _db.Database.RollbackTransactionAsync();

    }
}
