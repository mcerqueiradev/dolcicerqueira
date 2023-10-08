using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wapp_dolcicerqueira.Domain.Entities;

namespace wapp_dolcicerqueira.Repositories.Repositories.Interfaces
{
    public interface ITestemonialsRepository
    {
        Testemonials GetById(int id);
        Testemonials Add(Testemonials testemonials);
        List<Testemonials> GetAll();
        Testemonials Update(Testemonials testemonials);
        void Delete(int id);
    }
}
