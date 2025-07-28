using Lms.Core.Entities;
using Lms.Core.Interfaces;

namespace Lms.Infrastructure.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private List<Leave> _leaves = new List<Leave>();
        public void ApplyLeave(Leave leave)
        {

            _leaves.Add(leave);
            Console.WriteLine($"Leave applied: {leave.TypeOfLeave}\n");
        }

        public void UpdateLeave(int id, string status)
        {
            var leave = _leaves.FirstOrDefault(l => l.Id == id);
            leave.Status = status;
        }
        public void DeleteLeave(int id)
        {
            var leave = _leaves.FirstOrDefault(l => l.Id == id);
            if (leave != null)
            {
                _leaves.Remove(leave);
                Console.WriteLine($"Leave with ID {id} deleted.\n");
            }
            else
            {
                Console.WriteLine($"Leave with ID {id} not found.\n");
            }
        }
        public List<Leave> GetAll()
        {
            return _leaves;
        }
        public Leave GetById(int id)
        {
            return _leaves.FirstOrDefault(l => l.Id == id);
        }
    }
}
