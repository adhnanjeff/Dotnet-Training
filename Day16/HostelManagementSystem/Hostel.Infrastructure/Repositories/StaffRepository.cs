using Hostel.Core.Entities;

namespace Hostel.Infrastructure.Repositories
{
    public class StaffRepository
    {
        private readonly List<Staff> _staffs = new();
        public void Create(Staff room) => _staffs.Add(room);
        public Staff? GetById(int id) => _staffs.FirstOrDefault(r => r.Id == id);
        public List<Staff> GetAll() => _staffs;
    }
}
