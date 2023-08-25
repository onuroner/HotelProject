﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var rooms = _roomService.TGetAll();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var room = _roomService.TGetByID(id);
            return Ok(room);
        }

        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            _roomService.TInsert(room);
            return Ok(room);
        }

        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _roomService.TUpdate(room);
            return Ok(room);
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var room = _roomService.TGetByID(id);
            _roomService.TDelete(room);
            return Ok(room);
        }
    }
}
