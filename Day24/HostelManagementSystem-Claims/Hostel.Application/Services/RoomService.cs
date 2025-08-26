using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;

namespace Hostel.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepo;
        private readonly IStaffRepository _staffRepo;

        public RoomService(IRoomRepository roomRepo, IStaffRepository staffRepo)
        {
            _roomRepo = roomRepo;
            _staffRepo = staffRepo;
        }

        public void CreateRoom(RoomRequestDTO roomDto)
        {
            var availableStaff = _staffRepo
                .GetAll()
                .FirstOrDefault(s => s.Rooms.Count < 2);

            if (availableStaff == null)
            {
                throw new ArgumentException("No available staff to assign this room.");
            }

            int nextId = _roomRepo.GetAll().Any()
                ? _roomRepo.GetAll().Max(r => r.Id) + 1
                : 1;

            var room = new Room
            {
                Id = nextId,
                StaffId = availableStaff.Id,
                Staff = availableStaff,
                Students = new List<Student>()
            };

            availableStaff.Rooms.Add(room);
            _roomRepo.Create(room);
        }

        public RoomResponseDTO GetRoomById(int id)
        {
            var room = _roomRepo.GetById(id);

            return new RoomResponseDTO
            {
                Id = room.Id,
                StaffId = room.StaffId,
                StaffName = room.Staff?.Name,
                StudentNames = room.Students.Select(s => s.Name).ToList()
            };
        }


        public List<RoomResponseDTO> GetAllRooms()
        {
            return _roomRepo.GetAll()
                .Select(r => new RoomResponseDTO
                {
                    Id = r.Id,
                    StaffId = r.StaffId,
                    StaffName = r.Staff?.Name,
                    StudentNames = r.Students.Select(s => s.Name).ToList()
                })
                .ToList();
        }
    }
}
