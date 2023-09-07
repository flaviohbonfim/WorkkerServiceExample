using WorkerServiceExample.Data.Contexts;
using WorkerServiceExample.Data.Entities;

namespace WorkerServiceExample.Data.Repository;
public class ItemRepository : Repository<Item>
{
    private readonly ServiceDbContext _dbContext;
    public ItemRepository(ServiceDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    // Adicione métodos de consulta específicos para a classe Item, por exemplo, para buscar por nome.
    public IEnumerable<Item> GetItemsByName(string name)
    {
        return _dbContext.Item.Where(e => e.Name == name).ToList();
    }
}
