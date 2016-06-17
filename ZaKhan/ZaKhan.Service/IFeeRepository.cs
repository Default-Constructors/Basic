using System;
using System.Collections.Generic;
using ZaKhan.Data;

namespace ZaKhan.Service
{
   public interface IFeeRepository:IDisposable
    {
        Fee GetById(Int32 id);
        List<Fee> GetAll();
        void Insert(Fee model);
        void Update(Fee model);
        void Delete(Fee model);
        IEnumerable<Fee> Find(Func<Fee, bool> predicate);
    }
}
