using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Services.Interfaces;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace wapp_dolcicerqueira.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetAll()
        {
            var products = _productRepository.GetAll();
            foreach (var product in products)
            {
                product.Category = _categoryRepository.GetById(product.CategoryId);     
            }
            return products;
        }

        public IEnumerable<Product> Search(string searchTerm)
        {
            return _productRepository.GetAll()
                .Where(r => r.Name.Contains(searchTerm))
                .ToList();
        }

        public Product Save(Product product)
        {
            if (product.Id > 0)
                return _productRepository.Update(product);
            else
                return _productRepository.Add(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
