using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.IRepository
{
    public interface IHotelRoomRepository
    {
        public Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO);

        public Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO);

        public Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms();

        public Task<HotelRoomDTO> GetHotelRoom(int roomId);

        public Task<int> DeleteHotelRoom(int roomId);

        public Task<HotelRoomDTO> IsRoomUnique(string name,int roomId=0);
    }
}
