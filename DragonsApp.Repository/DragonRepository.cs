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
        return _db.Dragons
            .Include(dragon => dragon.Histories)
            .FirstOrDefault(dragon => dragon.Id == id);
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
        var found = _db.Dragons
            .AsNoTracking()
            .Include(dragon_ => dragon_.Histories)
            .FirstOrDefault(dragon_ => dragon_.Id == dragon.Id);

        if (found != null)
        {
            if (dragon.Histories != null)
            {
                if (found.Histories != null)
                {
                    foreach (var history in found.Histories)
                    {
                        if (!dragon.Histories.Any(history_ => history_.Id == history.Id))
                        {
                            _db.Remove(history);
                        }
                    }
                }
                _db.SaveChanges();
                _db.ChangeTracker.Clear();
                foreach (var history in dragon.Histories)
                {
                    if (history.Id != 0)
                    {
                        _db.Update(history);
                    }
                }
            }
            dragon.CreatedAt = found.CreatedAt;
            var updated = _db.Update(dragon).Entity;
            _db.SaveChanges();
            return updated;
        }
        else
        {
            return null;
        }
    }
}
