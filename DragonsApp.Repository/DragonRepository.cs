using DragonsApp.Database;
using DragonsApp.Models;

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
        _db.Remove(delete);
        var deleted = _db.SaveChanges();
        return deleted > 0;
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

    public Dragon Update(Dragon dragon)
    {
        var updated = _db.Update(dragon).Entity;
        _db.SaveChanges();
        return updated;
    }
}
