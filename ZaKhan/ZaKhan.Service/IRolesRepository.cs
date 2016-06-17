using System;
using System.Collections.Generic;
using ZaKhan.Data;

namespace ZaKhan.Service
{
    public interface IRolesRepository: IDisposable
    {
        List<ApplicationRole> GetAll();
        void Insert(ApplicationRole model);
        void Update(ApplicationRole model);
        void Delete(ApplicationRole model);
        IEnumerable<ApplicationRole> Find(Func<ApplicationRole, bool> predicate);
    }
}
