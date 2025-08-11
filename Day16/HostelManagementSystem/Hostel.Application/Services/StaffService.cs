using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;

namespace Hostel.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly IRepository<Staff> _staffRepo;
        private int _idCounter = 1;

        public StaffService(IRepository<Staff> staffRepo)
        {
            _staffRepo = staffRepo;
        }

        public void CreateStaff(StaffRequestDTO staffDto)
        {
            if (staffDto == null || string.IsNullOrWhiteSpace(staffDto.Name))
                throw new ArgumentException("Invalid staff data.");

            var staff = new Staff
            {
                Id = _idCounter++,
                Name = staffDto.Name
            };
            _staffRepo.Create(staff);
        }

        public StaffResponseDTO? GetStaffById(int id)
        {
            var staff = _staffRepo.GetById(id);
            if (staff == null)
                return null;

            return new StaffResponseDTO
            {
                Id = staff.Id,
                Name = staff.Name,
                RoomIds = staff.RoomIds ?? new List<int>()
            };
        }

        public List<StaffResponseDTO> GetAllStaff()
        {
            return _staffRepo.GetAll()
                .Select(s => new StaffResponseDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    RoomIds = s.RoomIds ?? new List<int>()
                })
                .ToList();
        }

        public bool AssignRoomToStaff(int staffId, int roomId)
        {
            var staff = _staffRepo.GetById(staffId);
            if (staff == null)
                return false;

            if (staff.RoomIds == null)
                staff.RoomIds = new List<int>();

            if (staff.RoomIds.Count < 2)
            {
                staff.RoomIds.Add(roomId);
                return true;
            }
            return false;
        }
    }
}

