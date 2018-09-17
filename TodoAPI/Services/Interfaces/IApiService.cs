using System.Collections.Generic;

    public interface IApiService<T>
    {
        List<T> GetAll();

        T GetById(long id);
        void Create(T item);
        T Delete(long id);
        T Update(long id, T item);
    }
