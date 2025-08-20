using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;
using Hostel.Infrastructure.Repositories;

namespace Hostel.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepo;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepo = staffRepository;
        }

        public void CreateStaff(StaffRequestDTO staffDto)
        {
            if (staffDto == null || string.IsNullOrWhiteSpace(staffDto.Name))
                throw new ArgumentException("Invalid staff data.");
            int nextId = _staffRepo.GetAll().Any()
                ? _staffRepo.GetAll().Max(r => r.Id) + 1
                : 1;

            var staff = new Staff
            {
                Id = nextId,
                Name = staffDto.Name,
                Rooms = new List<Room>() 
            };
            _staffRepo.Create(staff);
        }

        public StaffResponseDTO GetStaffById(int id)
        {
            var staff = _staffRepo.GetById(id);
            return new StaffResponseDTO
            {
                Id = id,
                Name = staff.Name
            };
        }

        public List<StaffResponseDTO> GetAllStaffs()
        {
            List<Staff> staffs = _staffRepo.GetAll();

            return staffs
                .Select(s => new StaffResponseDTO
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToList();
        }
    }
}

