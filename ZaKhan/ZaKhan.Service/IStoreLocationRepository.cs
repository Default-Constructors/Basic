using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaKhan.Data;



namespace ZaKhan.Service
{
    public interface IStoreLocationRepository : IDisposable
    {
        StoreLocation GetById(Int32 id);
        List<StoreLocation> GetAll();
        void Insert(StoreLocation model);
        void Update(StoreLocation model);
        void Delete(StoreLocation model);
        IEnumerable<StoreLocation> Find(Func<StoreLocation, bool> predicate);

    }
}
