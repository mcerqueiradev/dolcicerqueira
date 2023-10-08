using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Interfaces
{
    public interface ITestemonialsService
    {
        Testemonials GetById(int id);
        List<Testemonials> GetAll();
        Testemonials Save(Testemonials testemonials);
        void Delete(int id);
    }
}
