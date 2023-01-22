using DragonsApp.Database;
using DragonsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DragonsApp.Repository;

public class DragonRepository : IDragonRepository
{
    private readonly DragonsDbContext _db;

    public DragonRepository(DragonsDbContext db)
    {
        _db = db;
    }

    public Dragon Add(Dragon dragon)
    {
        var added = _db.Add(dragon).Entity;
        _db.SaveChanges();
        return added;
    }

    public bool Delete(int id)
    {
        var delete = new Dragon() { Id = id };
        try
        {
            _db.Remove(delete);
            _db.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }

        return true;
    }

    public Dragon? Get(int id)
    {
        return _db.Dragons.Find(id);
    }

    public List<Dragon> GetAll()
    {
        return _db.Dragons.ToList();
    }

    public List<Dragon> Search(ISearchParams searchParams)
    {
        throw new NotImplementedException();
    }

    public Dragon? Update(Dragon dragon)
    {
        try
        {
            var updated = _db.Update(dragon).Entity;
            _db.SaveChanges();
            return updated;
        }
        catch (DbUpdateConcurrencyException)
        {
            return null;
        }
    }
}
