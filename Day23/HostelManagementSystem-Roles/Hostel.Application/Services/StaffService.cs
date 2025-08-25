using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Exceptions;
using Hostel.Core.Interfaces;
using Hostel.Infrastructure.Repositories;
using System.ComponentModel;

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
            // Password check (from request instead of Console)
            if (staffDto.Password.Length < 6)
            {
                throw new ValidationException(new Dictionary<string, string>
                {
                    { "Failed", "Password too short"  }
                });
            }

            if (_staffRepo.GetAll().Any(s => s.Name == staffDto.Name))
                throw new ConflictException($"A staff member with the name {staffDto.Name} already exists");


            if (string.IsNullOrEmpty(staffDto.Password) || staffDto.Password != "1234567")
                throw new UnauthorizedException("You must be logged in to perform this action");


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
            if(id == 0)
            {
                throw new NotFoundException($"Staff with ID {id} was not found ");
            }
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

