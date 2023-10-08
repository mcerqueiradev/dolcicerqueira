using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Services.Interfaces;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category Save(Category category)
        {
            if (category.Id > 0)
                return _categoryRepository.Update(category);
            else
                return _categoryRepository.Add(category);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }
    }
}
