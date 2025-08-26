using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;

namespace Hostel.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IRoomRepository _roomRepo;

        public StudentService(IStudentRepository studentRepo, IRoomRepository roomRepo)
        {
            _studentRepo = studentRepo;
            _roomRepo = roomRepo;
        }

        public void CreateStudent(StudentRequestDTO studentDto)
        {
            // Find first available room with < 2 students
            var availableRoom = _roomRepo
                .GetAll()
                .FirstOrDefault(r => r.Students.Count < 2);

            if (availableRoom == null)
                throw new ArgumentException("No available room for this student.");

            // Generate new ID
            int nextId = _studentRepo.GetAll().Any()
                ? _studentRepo.GetAll().Max(s => s.Id) + 1
                : 1;

            var student = new Student
            {
                Id = nextId,
                Name = studentDto.Name,
                RoomId = availableRoom.Id
            };

            // Add student to room entity
            availableRoom.Students.Add(student);

            // Save to repositories
            _studentRepo.Create(student);
            //_roomRepo.Update(availableRoom);
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

        public void DeleteStudent(int id)
        {
            _studentRepo.Delete(id);
        }

        public void UpdateStudent(int id, StudentRequestDTO stud)
        {
            var existingStudent = _studentRepo.GetById(id);
            if (existingStudent == null)
                throw new Exception("Student not found");

            existingStudent.Name = stud.Name;

            _studentRepo.Update(existingStudent);
        }

    }
}

