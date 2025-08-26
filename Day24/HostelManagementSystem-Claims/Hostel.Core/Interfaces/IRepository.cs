

namespace Hostel.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
