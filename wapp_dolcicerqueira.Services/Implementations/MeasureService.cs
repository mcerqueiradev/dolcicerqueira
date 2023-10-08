using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Services.Interfaces;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Services.Implementations
{
    public class MeasureService : IMeasureService
    {
        private readonly IMeasureRepository _measureRepository;

        public MeasureService(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
        }

        public Measure GetById(int id)
        {
            return _measureRepository.GetById(id);
        }

        public List<Measure> GetAll()
        {
            return _measureRepository.GetAll();
        }

        public Measure Save(Measure measure)
        {
            if (measure.Id > 0)
                return _measureRepository.Update(measure);
            else
                return _measureRepository.Add(measure);
        }

        public void Delete(int id)
        {
            _measureRepository.Delete(id);
        }
    }
}
