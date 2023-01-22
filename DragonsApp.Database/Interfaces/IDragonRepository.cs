using DragonsApp.Models;

namespace DragonsApp.Repository;

public interface IDragonRepository
{
    public List<Dragon> GetAll();
    public List<Dragon> Search(ISearchParams searchParams);
    public Dragon? Get(int id);
    public Dragon Add(Dragon dragon);
    public Dragon Update(Dragon dragon);
    public bool Delete(int id);
}
