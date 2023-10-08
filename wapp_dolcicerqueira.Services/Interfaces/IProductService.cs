using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Interfaces
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();

        IEnumerable<Product> Search(string searchTerm);
        Product Save(Product product);
        void Delete(int id);
    }
}
