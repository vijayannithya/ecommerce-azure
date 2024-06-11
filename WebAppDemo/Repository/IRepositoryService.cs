using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Respository
{
    public interface IRepositoryService
    {
        Task Add(Product entity);
        Task<IEnumerable<Product>> GetById(int id);
       
        Task Update(Product entity);
        Task Remove(Product entity);
        Task<IEnumerable<Product>> Search(string name);
        Task<List<Product>> GetAll();
        Task<int> SaveChanges();

        
    }
}
