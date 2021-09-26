using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> ShowList();
        T GetById(int id);
        void Create(T entidade);
        void Delete(int id);
        void Update(int id, T entidade);
        int NextId();
        bool Exists(int id);
    }
}
