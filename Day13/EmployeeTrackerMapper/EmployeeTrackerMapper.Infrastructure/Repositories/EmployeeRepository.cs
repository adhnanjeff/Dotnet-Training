using EmployeeTrackerMapper.Core.Entities;
using EmployeeTrackerMapper.Core.Interfaces;

namespace EmployeeTrackerMapper.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new();

        public void Add(Employee entity)
        {
            int id = _employees.Count > 0 ? _employees.Max(e => e.Id) + 1 : 1; 
            entity.Id = id; 
            _employees.Add(entity);
        }
        public void Update(Employee entity)
        {
            var existing = _employees.FirstOrDefault(d => d.Id == entity.Id);
            if (existing != null)
            {
                existing.Name = entity.Name;
                existing.Role = entity.Role;
                existing.Salary = entity.Salary;
                existing.DepartmentId = entity.DepartmentId;
            }
        }

        public void Delete(int id)
        {
            var entity = _employees.FirstOrDefault(d => d.Id == id);
            if (entity != null)
            {
                _employees.Remove(entity);
            }
        }

        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(d => d.Id == id);
        }

        public List<Employee> GetAll() => _employees;
        
    }
}
