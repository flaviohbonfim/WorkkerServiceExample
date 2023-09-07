using WorkerServiceExample.Data.Contexts;
using WorkerServiceExample.Data.Entities;

namespace WorkerServiceExample.Data.Repository;
public class TestRepository : Repository<Test>
{
    private readonly InfraDbContext _dbContext;
    public TestRepository(InfraDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    // Adicione métodos de consulta específicos para a classe Item, por exemplo, para buscar por nome.
}
