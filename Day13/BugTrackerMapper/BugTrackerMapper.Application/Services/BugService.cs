using AutoMapper;
using BugTrackerMapper.Core.DTOs;
using BugTrackerMapper.Core.Entities;
using BugTrackerMapper.Core.Interfaces;


namespace BugTrackerMapper.Application.Services
{
    public class BugService
    {
        private readonly IBugRepository _bugRepository; 
        private readonly IMapper _mapper;
        public BugService(IBugRepository bugRepository, IMapper mapper)
        {
            _bugRepository = bugRepository;
            _mapper = mapper;
        }
        public void AddBug(BugRequestDTO bugDto)
        {
            var bug = _mapper.Map<Bug>(bugDto);
            _bugRepository.Add(bug);
        }
        public void GetAllBugs()
        {
            var bugs = _bugRepository.GetAll();
            var bugDtos = _mapper.Map<List<BugResponseDTO>>(bugs);
            foreach (var bug in bugDtos)
            {
                Console.WriteLine($"Id: {bug.Id}, Title: {bug.Title}, Status: {bug.Status}, DueDate: {bug.DueDate}");
            }
        }
        public BugRequestDTO? GetBugById(int id)
        {
            var bug = _bugRepository.GetById(id);
            return bug != null ? _mapper.Map<BugRequestDTO>(bug) : null;
        }
        public void UpdateBug(BugRequestDTO bugDto)
        {
            var bug = _mapper.Map<Bug>(bugDto);
            _bugRepository.Update(bug);
        }
        public void DeleteBug(int id)
        {
            _bugRepository.Delete(id);
        }
        
    }
}
