using System;
using System.Collections.Generic;
using System.Linq;
using ZaKhan.Data;

namespace ZaKhan.Service
{
    public class RolesRepository:IRolesRepository
    {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<ApplicationRole> _rolesRepository;

        public RolesRepository()
        {
            _datacontext = new ApplicationDbContext();
            _rolesRepository = new RepositoryService<ApplicationRole>(_datacontext);

        }

        public List<ApplicationRole> GetAll()
        {
            return _rolesRepository.GetAll().ToList();
        }

        public void Insert(ApplicationRole model)
        {
            _rolesRepository.Insert(model);
        }

        public void Update(ApplicationRole model)
        {
            _rolesRepository.Update(model);
        }

        public void Delete(ApplicationRole model)
        {
            _rolesRepository.Delete(model);
        }

        public IEnumerable<ApplicationRole> Find(Func<ApplicationRole, bool> predicate)
        {
            return _rolesRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            //_datacontext.Dispose();
            _datacontext = null;
        }
    }
}
