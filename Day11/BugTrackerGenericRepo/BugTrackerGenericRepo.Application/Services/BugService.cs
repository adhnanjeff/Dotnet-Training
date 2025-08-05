using BugTrackerGenericRepo.Core.Interfaces;
using BugTrackerGenericRepo.Core.Entities;

namespace BugTrackerGenericRepo.Application.Services
{
    public class BugService
    {
        private readonly IBugRepository _bugRepository;
        public BugService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }
        public void AddBug(Bug bug)
        {
            _bugRepository.Add(bug);
        }
        public void UpdateBug(Bug bug)
        {
            _bugRepository.Update(bug);
        }
        public void DeleteBug(int id)
        {
            _bugRepository.Delete(id);
        }
        public  Bug? GetBugById(int id)
        {
            return _bugRepository.GetById(id);
        }
        public List<Bug> GetAllBugs()
        {
            return _bugRepository.GetAll();
        }
    }
}
