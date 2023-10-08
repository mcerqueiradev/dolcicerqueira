using wapp_dolcicerqueira.Domain.Entities;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Interfaces
{
    public interface IMeasureService
    {
        Measure GetById(int id);
        List<Measure> GetAll();
        Measure Save(Measure measure);
        void Delete(int id);
    }
}
