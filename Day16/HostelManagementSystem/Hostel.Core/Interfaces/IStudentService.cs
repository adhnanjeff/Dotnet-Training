using Hostel.Core.DTOs;

namespace Hostel.Core.Interfaces
{
    public interface IStudentService
    {
        void CreateStudent(StudentRequestDTO student);
        StudentResponseDTO GetStudentById(int id);
        List<StudentResponseDTO> GetAllStudents();
    }
}
