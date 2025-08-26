using Hostel.Core.Entities;
using Hostel.Core.Interfaces;

namespace Hostel.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new();
        public void Create(Student room) => _students.Add(room);
        public Student? GetById(int id) => _students.FirstOrDefault(r => r.Id == id);
        public List<Student> GetAll() => _students;
        public void Delete(int id)
        {
            var existing = _students.FirstOrDefault(s => s.Id == id);
            if (existing != null)
            {
                _students.Remove(existing);
            }
        }

        public void Update(Student student)
        {
            var existing = _students.FirstOrDefault(s => s.Id == student.Id);
            existing.Name = student.Name;
        }
    }
}
