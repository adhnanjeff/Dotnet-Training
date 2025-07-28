using Lms.Core.Entities;
using Lms.Core.Interfaces;


namespace Lms.Application.Services
{
    public class LeaveService 
    {
        private readonly ILeaveRepository _repo;

        public string Status { get; private set; }

        public LeaveService(ILeaveRepository repo)
        {
            _repo = repo;
        }

        public void CreateLeave(string noe, string type)
        {
            var leave = new Leave
            {
                NameOfEmployee = noe, 
                TypeOfLeave = type, 
                Status = "Pending"
            };
            leave.Id = _repo.GetAll().Count + 1; // Simple ID generation logic, can be improved
            _repo.ApplyLeave(leave);
            Console.WriteLine($"Leave Applied: {leave.TypeOfLeave}");
        }

        public List<Leave> GetAllLeaves()
        {
            Console.WriteLine("Fetching all Leave Details...");
            return _repo.GetAll();
        }

        public void ApproveLeave() => Status = "Approved";
        public void RejectLeave() => Status = "Rejected";
    }
}
