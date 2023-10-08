using wapp_dolcicerqueira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wapp_dolcicerqueira.Repositories.Interfaces
{
    public interface IMeasureRepository
    {
        Measure GetById(int id);
        List<Measure> GetAll();
        Measure Add(Measure measure);
        Measure Update(Measure measure);
        void Delete(int id);
    }
}
