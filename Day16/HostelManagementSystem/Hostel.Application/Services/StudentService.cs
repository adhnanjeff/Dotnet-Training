using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;

namespace Hostel.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepo;
        private int _idCounter = 1;

        public StudentService(IRepository<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public void CreateStudent(StudentRequestDTO studentDto)
        {
            var student = new Student
            {
                Id = _idCounter++,
                Name = studentDto.Name
            };
            _studentRepo.Create(student);
        }

        public StudentResponseDTO GetStudentById(int id)
        {
            var student = _studentRepo.GetById(id);
            return new StudentResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                RoomId = student.RoomId
            };
        }

        public List<StudentResponseDTO> GetAllStudents()
        {
            return _studentRepo.GetAll()
                .Select(s => new StudentResponseDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    RoomId = s.RoomId
                })
                .ToList();
        }
    }
}

