using EventEase.Core.Entities;
using EventEase.Core.Interfaces;


namespace EventEase.Infrastructure.Repositories
{
    public class RegistrationRepository 
    {
        private readonly List<Registration> _register = new();

        public void Add(Registration reg)
        {
            _register.Add(reg);
        }

        public Registration? GetById(int id) => _register.FirstOrDefault(r => r.Id == id);

        public List<Registration> GetAll() => _register;
    }
}
