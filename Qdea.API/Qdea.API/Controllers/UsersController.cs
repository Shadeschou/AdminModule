using System.Collections.Generic;
using AutoMapper;
using DataLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using Qdea.API.Data;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUser _repository;

        public UsersController(IUser repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var UserItems = _repository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(UserItems));
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var UserItem = _repository.GetUserById(id);
            if (UserItem != null)
                return Ok(_mapper.Map<UserReadDto>(UserItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto UserCreateDto)
        {
            var UserModel = _mapper.Map<User>(UserCreateDto);
            _repository.CreateUser(UserModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<UserReadDto>(UserModel);
            return CreatedAtRoute(nameof(GetUserById), new {ID = outPut.UserID}, outPut);
            //return Ok(_mapper.Map<UserReadDto>(UserModel));
        }

        [HttpPut]
        public ActionResult UpdateUser(UserUpdateDto userUpdateDto)
        {
            var userModel = _repository.GetUserById(userUpdateDto.UserID);
            if (userModel == null) return NotFound();
            _mapper.Map(userUpdateDto, userModel);
            _repository.UpdateUser(userModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var UserToDelete = _repository.GetUserById(id);
            _repository.DeleteUser(UserToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}