using System;
using System.Collections.Generic;
using ZaKhan.Data;

namespace ZaKhan.Service
{
    public interface IPatientRepository : IDisposable
    {
        Patient GetById(int id);
        List<Patient> GetAll();
        void Insert(Patient model);
        void Update(Patient model);
        void Delete(Patient model);
        IEnumerable<Patient> Find(Func<Patient, bool> predicate);

    }
}
