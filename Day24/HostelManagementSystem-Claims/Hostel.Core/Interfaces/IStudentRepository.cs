using Hostel.Core.Entities;

namespace Hostel.Core.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        void Delete(int id);
        void Update(Student entity);
    }
}
