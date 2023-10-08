using wapp_dolcicerqueira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wapp_dolcicerqueira.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product GetById(int id);
        List<Product> GetAll();
        Product Add(Product product);
        Product Update(Product product);
        void Delete(int id);
    }
}
