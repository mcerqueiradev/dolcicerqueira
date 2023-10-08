using wapp_dolcicerqueira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wapp_dolcicerqueira.Repositories.Interfaces

{
    internal interface IOrderRepository
    {
        Order GetById(int id);
        Order Add(Order order);
        Order Update(Order order);
        void Delete(int id);
    }
}
