using Hostel.Core.DTOs;

namespace Hostel.Core.Interfaces
{
    public interface IStaffService
    {
        void CreateStaff(StaffRequestDTO staffDto);
        StaffResponseDTO GetStaffById(int id);
        List<StaffResponseDTO> GetAllStaffs();
    }
}
