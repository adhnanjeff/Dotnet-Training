using EmployeeTrackerGenericRepo.Core.Entities; 
using EmployeeTrackerGenericRepo.Core.Interfaces;

namespace EmployeeTrackerGenericRepo.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new();
        public void Add(Employee entity)
        {
            _employees.Add(entity);
        }
        public void Update(Employee entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null)
            {
                existing.EmpName = entity.EmpName;
                existing.Department = entity.Department;
            }
        }
        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _employees.Remove(entity);
            }
        }
        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
        public List<Employee> GetAll()
        {
            return _employees;
        }
    }
}
