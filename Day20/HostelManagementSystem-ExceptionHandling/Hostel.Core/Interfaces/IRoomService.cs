using Hostel.Core.DTOs;


namespace Hostel.Core.Interfaces
{
    public interface IRoomService
    {
        void CreateRoom(RoomRequestDTO roomDto);
        RoomResponseDTO GetRoomById(int roomId);
        List<RoomResponseDTO> GetAllRooms();
    }
}
