
namespace SportsStore.Models;

public class EFStoreRepository : IStoreRepository
{
    private StoreDbContext context;
    public EFStoreRepository(StoreDbContext cxt)
    {
        context = cxt;
    }
    public IQueryable<Product> Products => context.Products;
}
