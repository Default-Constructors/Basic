using System;
using System.Collections.Generic;
using System.Linq;
using ZaKhan.Data;

namespace ZaKhan.Service
{
    public class PatientRepository :IPatientRepository
    {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<Patient> _storeLocationRepository;

        public PatientRepository()
        {
            _datacontext = new ApplicationDbContext();
            _storeLocationRepository = new RepositoryService<Patient>(_datacontext);

        }

        public Patient GetById(int id)
        {
            return _storeLocationRepository.GetById(id);
        }

        public List<Patient> GetAll()
        {
            return _storeLocationRepository.GetAll().ToList();
        }

        public void Insert(Patient model)
        {
            _storeLocationRepository.Insert(model);
        }

        public void Update(Patient model)
        {
            _storeLocationRepository.Update(model);
        }

        public void Delete(Patient model)
        {
            _storeLocationRepository.Delete(model);
        }

        public IEnumerable<Patient> Find(Func<Patient, bool> predicate)
        {
            return _storeLocationRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
