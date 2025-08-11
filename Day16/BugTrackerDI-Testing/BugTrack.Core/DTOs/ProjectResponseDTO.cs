

namespace BugTrack.Core.DTOs
{
    public class ProjectResponseDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
