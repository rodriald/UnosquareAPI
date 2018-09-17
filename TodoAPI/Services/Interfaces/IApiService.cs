using System.Collections.Generic;

    public interface IApiService<T>
    {
        List<T> GetAll();

        T GetById(long id);
        long Create(T item, out string todotype);
        T Delete(long id);
        T Update(long id, T item);
    }
