using Hostel.Core.Entities;
using Hostel.Core.Interfaces;

namespace Hostel.Infrastructure.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly List<Staff> _staffs = new();
        public void Create(Staff staff) => _staffs.Add(staff);
        public Staff? GetById(int id) => _staffs.FirstOrDefault(r => r.Id == id);
        public List<Staff> GetAll() => _staffs;

        public void Delete(int id)
        {
            var existing = _staffs.FirstOrDefault(r => r.Id == id);
            if (existing != null)
                _staffs.Remove(existing);
            else
                throw new ArgumentException($"Staff with Id {id} not found.");
        }


        public void Update(Staff staff)
        {
            var existing = _staffs.FirstOrDefault(r => r.Id == staff.Id);
            if (existing != null)
            {
                existing.Name = staff.Name;
                existing.Rooms = staff.Rooms;
            }
            else
            {
                throw new ArgumentException($"Staff with Id {staff.Id} not found.");
            }
        }

    }
}
