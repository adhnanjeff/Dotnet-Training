using EmployeeTrackerMapper.Core.Entities;
using EmployeeTrackerMapper.Core.Interfaces;

namespace EmployeeTrackerMapper.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly List<Department> _department = new();

        public void Add(Department entity)
        {
            int id = _department.Count > 0 ? _department.Max(d => d.Id) + 1 : 1; 
            entity.Id = id; 
            _department.Add(entity);
        }

        public void Update(Department entity)
        {
            var existing = _department.FirstOrDefault(d => d.Id == entity.Id);
            if (existing != null)
            {
                existing.Name = entity.Name;
            }
        }

        public void Delete(int id)
        {
            var entity = _department.FirstOrDefault(d => d.Id == id);
            if (entity != null)
            {
                _department.Remove(entity);
            }
        }

        public Department? GetById(int id)
        {
            return _department.FirstOrDefault(d => d.Id == id);
        }

        public List<Department> GetAll()
        {
            return _department;
        }
    }
}
