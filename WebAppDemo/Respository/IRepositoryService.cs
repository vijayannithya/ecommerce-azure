using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Respository
{
    public interface IRepositoryService
    {
        Task Add(Product entity);
        Task<Product> GetById(int id);
        Task<List<Product>> GetAll();
        Task Update(Product entity);
        Task Remove(Product entity);
        Task<IEnumerable<Product>> Search(Expression<Func<Product, bool>> predicate);
        Task<int> SaveChanges();
    }
}
