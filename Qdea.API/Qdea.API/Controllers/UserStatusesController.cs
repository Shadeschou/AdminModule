using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Qdea.API.Data;
using Qdea.API.Domain;
using DataLayer.Dtos;

namespace Qdea.API.Controllers
{
    [Route("api/userstatuses")]
    [ApiController]
    public class UserStatusesController : ControllerBase
    {
        private readonly IUserStatus _repository;
        private readonly IMapper _mapper;

        public UserStatusesController(IUserStatus repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserStatusReadDto>> GetAllUsers()
        {
            var UserStatuses = _repository.GetAllUserStatuses();
            return Ok(_mapper.Map<IEnumerable<UserStatusReadDto>>(UserStatuses));
        }

        [HttpGet("{id}", Name = "GetUserStatusById")]
        public ActionResult<UserStatusReadDto> GetUserStatusById(int id)
        {
            var UserStatusItem = _repository.GetUserStatusById(id);
            if (UserStatusItem != null)
            {
                return Ok(_mapper.Map<UserStatusReadDto>(UserStatusItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<UserStatusReadDto> CreateUseStatusr(UserStatusCreateDto UserStatusCreateDto)
        {
            var UserStatusModel = _mapper.Map<UserStatus>(UserStatusCreateDto);
            _repository.CreateUserStatus(UserStatusModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<UserStatusReadDto>(UserStatusModel);
            return CreatedAtRoute(nameof(GetUserStatusById), new { ID = outPut.UserStatusID }, outPut);
            //return Ok(_mapper.Map<UserStatusReadDto>(UserStatusModel));
        }

        [HttpPut]
        public ActionResult UpdateUserStatus(int id, UserStatusUpdateDto userStatusUpdateDto)
        {
            var userStatusModel = _repository.GetUserStatusById(userStatusUpdateDto.UserStatusID);
            if (userStatusModel == null) return NotFound();
            _mapper.Map(userStatusUpdateDto, userStatusModel);
            _repository.UpdateUserStatus(userStatusModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUserStatus(int id)
        {
            var UserStatusToDelete = _repository.GetUserStatusById(id);
            _repository.DeleteUserStatus(UserStatusToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}