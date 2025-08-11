using Hostel.Core.Entities;

namespace Hostel.Infrastructure.Repositories
{
    public class StudentRepository
    {
        private readonly List<Student> _students = new();
        public void Create(Student room) => _students.Add(room);
        public Student? GetById(int id) => _students.FirstOrDefault(r => r.Id == id);
        public List<Student> GetAll() => _students;
    }
}
