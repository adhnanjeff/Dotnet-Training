using Hostel.Core.Entities;

namespace Hostel.Infrastructure.Repositories
{
    public class RoomRepository
    {
        private readonly List<Room> _rooms = new();
        public void Create(Room room) => _rooms.Add(room);
        public Room? GetById(int id) => _rooms.FirstOrDefault(r => r.Id == id);
        public List<Room> GetAll() => _rooms;
        
    }
}
