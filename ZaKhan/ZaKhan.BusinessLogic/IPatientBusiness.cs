using System.Collections.Generic;
using ZaKhan.Data;
using ZaKhan.Model;

namespace ZaKhan.BusinessLogic
{
   public interface IPatientBusiness
    {
       List<PatientViewModel> GetAllPatients();
       void Insert(PatientViewModel patientModel);
       void Update(PatientViewModel patientModel);
       void Delete(PatientViewModel patientModel);
        PatientViewModel GetById(int id);
        void UpdatePatient(PatientViewModel patientModel);
        PatientViewModel ReturnPatient(string username);
        PatientViewModel GetOne(string username);
        Patient get(string username);
        void Dispose(bool disposing);
       
    }
}
