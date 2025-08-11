using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;

namespace Hostel.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<Student> _studentRepo;
        private int _idCounter = 1;

        public RoomService(IRepository<Room> roomRepo, IRepository<Student> studentRepo)
        {
            _roomRepo = roomRepo;
            _studentRepo = studentRepo;
        }

        public void CreateRoom(RoomRequestDTO roomDto)
        {
            var room = new Room
            {
                Id = _idCounter++,
                StaffId = roomDto.StaffId
            };
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
                StudentIds = room.Students.Select(s => s.Id).ToList()
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
                    StudentIds = r.Students.Select(s => s.Id).ToList()
                })
                .ToList();
        }
    }
}
