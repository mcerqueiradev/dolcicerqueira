using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Services.Interfaces;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using wapp_dolcicerqueira.Repositories.Implementations;
using wapp_dolcicerqueira.Repositories.Repositories.Interfaces;

namespace wapp_dolcicerqueira.Services.Implementations
{
    public class TestemonialsService : ITestemonialsService
    {
        private readonly ITestemonialsRepository _testemonialsRepository;

        public TestemonialsService(ITestemonialsRepository testemonialsRepository)
        {
            _testemonialsRepository = testemonialsRepository;
        }

        public List<Testemonials> GetAll()
        {
            return _testemonialsRepository.GetAll();
        }

        public Testemonials GetById(int id)
        {
            return _testemonialsRepository.GetById(id);     
        }
        public Testemonials Save(Testemonials testemonials)
        {
            if (testemonials.Id > 0)
                return _testemonialsRepository.Update(testemonials);
            else
                return _testemonialsRepository.Add(testemonials);
        }

        public void Delete(int id)
        {
            _testemonialsRepository.Delete(id);
        }
    }
}
