using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HopitalConsoleMatmut.Repository
{
    public interface IRepository<T, PK> where T : class
                                        where PK: struct
    {
        T? GetById(PK id);

        List<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Remove(PK id);
    }
}
