using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Linq;
namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
    }
}