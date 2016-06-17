using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ZaKhan.Data;
using ZaKhan.Model;
using ZaKhan.Service;

namespace ZaKhan.BusinessLogic
{
   public class PatientBusiness : IPatientBusiness
    {
       public List<PatientViewModel> GetAllPatients()
        {
            using (var patientrepo = new PatientRepository())
            {
                return patientrepo.GetAll().Select(x => new PatientViewModel() { PatientId = x.PatientId, FirstName = x.FirstName, LastName = x.LastName, IdentificationNumber = x.IdentificationNumber, Cellphone = x.Cellphone, Email = x.Email, Occupation = x.Occupation,SecurityAnswer = x.SecurityAnswer,Address = x.Address,Telephone = x.Telephone,City = x.City,State = x.State,Country = x.Country,ZipCode = x.ZipCode}).ToList();
            }
        }

		//2 convert

        private static Patient ConvertToViewModel(PatientViewModel model)
        {
            var ash = new Patient
            {
                Cellphone = model.Cellphone,
                Email = model.Email,
                FirstName = model.FirstName,
                SecurityAnswer = model.SecurityAnswer,
                IdentificationNumber = model.IdentificationNumber,
                LastName = model.LastName,
                Occupation = model.Occupation,
                PatientId = model.PatientId,
                SecurityQuestion = model.SecurityQuestion,
                UserName = model.UserName,
                Address = model.Address,
                Telephone = model.Telephone,
                City = model.City,
                State = model.State,
                Country = model.Country,
                ZipCode = model.ZipCode
                
            };
            return ash;
        }


       public void Insert(PatientViewModel patientModel)
        {
            using (var repo = new PatientRepository())
            {
                var dis = new Patient();
                if (true)
                {
                    dis.PatientId = patientModel.PatientId;

                    dis.UserName = patientModel.UserName;
                    dis.FirstName = patientModel.FirstName;
                    dis.LastName = patientModel.LastName;
                    dis.IdentificationNumber = patientModel.IdentificationNumber;
                    dis.Cellphone = patientModel.Cellphone;
                    dis.Email = patientModel.Email;
                    dis.Occupation = patientModel.Occupation;
                    dis.SecurityAnswer = patientModel.SecurityAnswer;
                    dis.Address = patientModel.Address;
                    dis.Telephone = patientModel.Telephone;
                    dis.City = patientModel.City;
                    dis.State = patientModel.State;
                    dis.Country = patientModel.Country;
                    dis.ZipCode = patientModel.ZipCode;

                }
                repo.Insert(dis);
                AddUserToPatientRole(dis.UserName);
            }
        }

        public void Update(PatientViewModel patientModel)
        {
            using (var repo = new PatientRepository())
            {
                var dis = new Patient();
                dis = repo.GetById(patientModel.PatientId);
                if (true)
                {
                    dis.UserName = patientModel.UserName;
                    dis.FirstName = patientModel.FirstName;
                    dis.LastName = patientModel.LastName;
                    dis.IdentificationNumber = patientModel.IdentificationNumber;
                    dis.Cellphone = patientModel.Cellphone;
                    dis.Email = patientModel.Email;
                    dis.Occupation = patientModel.Occupation;
                    dis.SecurityAnswer = patientModel.SecurityAnswer;
                    dis.Address = patientModel.Address;
                    dis.Telephone = patientModel.Telephone;
                    dis.City = patientModel.City;
                    dis.State = patientModel.State;
                    dis.Country = patientModel.Country;
                    dis.ZipCode = patientModel.ZipCode;

                }
                repo.Update(dis);


            }
        }

        public void Delete(PatientViewModel patientModel)
        {
            using (var repo = new PatientRepository())
            {
                var dis = new Patient();
                dis = repo.GetById(patientModel.PatientId);
                repo.Delete(dis);
            }

        }

		//change this
       public PatientViewModel GetById(int id)
        {
            using (var repo = new PatientRepository())
            {
                return GetAllPatients().Find(x => x.PatientId == id);
            }
        }


       private void AddUserToPatientRole(string username)
       {
           ApplicationDbContext context = new ApplicationDbContext();
           var idman = new IdentityManager();
           var user = context.Users.First(x => x.UserName == username);
           idman.AddUserToRole(user.Id, "Patient");
       }


       public void UpdatePatient(PatientViewModel patientModel)
       {
           ApplicationDbContext db = new ApplicationDbContext();
           var user = db.Users.First(x => x.UserName == patientModel.UserName);
           user.Email = patientModel.Email;
           user.FirstName = patientModel.FirstName;
           user.LastName = patientModel.LastName;
           db.Entry(user).State = EntityState.Modified;
           db.SaveChangesAsync();
       }




       public PatientViewModel ReturnPatient(string username)
       {
           using (var repo = new PatientRepository())
           {
                return GetAllPatients().Find(x => x.UserName == username);
                //return ConvertToViewModel(repo.GetAll().Find(x => x.UserName.Equals(username)));
           }
       }

       public  Patient get(string username)
       {
           ApplicationDbContext db = new ApplicationDbContext();
           return db.Patients.SingleOrDefault(x => x.UserName.Equals(username));
       }


        public void Dispose(bool disposing)
        {
            using (var repo = new PatientRepository())
            {
                repo.Dispose();
            }
        }

        public PatientViewModel GetOne(string username)
        {
            return GetAllPatients().Find(x => x.UserName.Equals(username));
        }
    }
}



 