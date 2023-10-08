using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Interfaces
{
    public interface ICategoryService
    {
        Category GetById(int id);
        List<Category> GetAll();
        Category Save(Category category);
        void Delete(int id);
    }
}
