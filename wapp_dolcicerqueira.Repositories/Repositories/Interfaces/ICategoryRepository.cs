using wapp_dolcicerqueira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wapp_dolcicerqueira.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetById(int id);
        List<Category> GetAll();
        Category Add(Category category);
        Category Update(Category category);
        void Delete(int id);
    }
}
