

namespace BankPro.Core.Interfaces
{
    public interface IRepository <T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int Id);
        T? GetById(int Id);
        List<T> GetAll();
    }
}
