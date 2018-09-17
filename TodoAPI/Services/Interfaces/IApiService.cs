using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public interface IApiService<T>
    {
        List<T> GetAll();

        T GetById(long id);
        void Create(T item);
        T Delete(long id);
        T Update(long id, T item);
    }
