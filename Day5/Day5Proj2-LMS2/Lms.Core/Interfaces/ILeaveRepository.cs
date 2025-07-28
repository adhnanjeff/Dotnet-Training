using Lms.Core.Entities;

namespace Lms.Core.Interfaces
{
    public interface ILeaveRepository
    {
        void ApplyLeave(Leave leave);
        void DeleteLeave(int id);
        void UpdateLeave(int id, string status);
        List<Leave> GetAll();
        Leave GetById(int id);
    }
}
