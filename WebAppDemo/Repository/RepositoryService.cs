using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository;


namespace Respository
{
    public class RepositoryService : IRepositoryService
    {
        protected readonly CatalogContext eshopDb;

        protected readonly DbSet<Product> ProductSet;

        protected RepositoryService(CatalogContext db)
        {
            eshopDb = db;
            ProductSet = db.Set<Product>();
        }

        
        public async Task<IEnumerable<Product>> Search(string name)
        {
            return await ProductSet.AsNoTracking().Where(c => c.ProductName == name).ToListAsync(); 
            
        }

        public  async Task<IEnumerable<Product>> GetById(int id)
        {

            return await ProductSet.AsNoTracking().Where(c => c.ProductId == id).ToListAsync();
           
        }
        
       
        public  async Task<List<Product>> GetAll()
        {
            return await ProductSet.ToListAsync();
        }

        public  async Task Add(Product entity)
        {
            ProductSet.Add(entity);
            await SaveChanges();
        }

        public  async Task Update(Product entity)
        {
            ProductSet.Update(entity);
            await SaveChanges();
        }

        public  async Task Remove(Product entity)
        {
            ProductSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await eshopDb.SaveChangesAsync();
        }

        public void Dispose()
        {
            eshopDb?.Dispose();
        }
    }
}

