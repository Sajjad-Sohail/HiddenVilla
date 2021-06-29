﻿using AutoMapper;
using BusinessLayer.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public HotelRoomRepository(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO)
        {
            HotelRoom hotelRoom = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO);
            hotelRoom.CreatedDate = DateTime.Now;
            hotelRoom.CreatedBy = "";
            var addedHotelRoom = await _db.HotelRooms.AddAsync(hotelRoom);
            await _db.SaveChangesAsync();
            return _mapper.Map<HotelRoom, HotelRoomDTO>(addedHotelRoom.Entity);

        }

        public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms()
        {
            try {
                IEnumerable<HotelRoomDTO> hotelRoomDTOs = _mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDTO>>(_db.HotelRooms);
                return hotelRoomDTOs;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public async Task<HotelRoomDTO> GetHotelRoom(int roomId) {
            try
            {
                HotelRoomDTO hotelRoom = _mapper.Map<HotelRoom,HotelRoomDTO>(await _db.HotelRooms.FirstOrDefaultAsync(x => x.Id == roomId));

                return hotelRoom;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<int> DeleteHotelRoom(int roomId)
        {
            var roomDetails = await _db.HotelRooms.FindAsync(roomId);
            if(roomDetails != null)
            {
                _db.HotelRooms.Remove(roomDetails);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<HotelRoomDTO> IsRoomUnique(string name)
        {
            try
            {
                HotelRoomDTO hotelRoom = _mapper.Map<HotelRoom, HotelRoomDTO>(await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));

                return hotelRoom;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO)
        {
            try {
                if (roomId == hotelRoomDTO.Id)
                {
                    HotelRoom roomDetails = await _db.HotelRooms.FindAsync(roomId);
                    HotelRoom room = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO, roomDetails);

                    room.UpdatedBy = "";
                    room.UpdateDate = DateTime.Now;
                    var updatedRoom =   _db.HotelRooms.Update(room);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<HotelRoom, HotelRoomDTO>(updatedRoom.Entity);


                }
                else
                {
                    return null;//log error
                }
            }
            catch(Exception e)
            {
                return null;//log error
            }
        }
    }
}
