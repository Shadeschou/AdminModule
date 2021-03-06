using System.Collections.Generic;
using AutoMapper;
using DataLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using Qdea.API.Data;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/addedusers")]
    [ApiController]
    public class AddedUsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAddedUser _repository;

        public AddedUsersController(IAddedUser repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AddedUserReadDto>> GetAllAddedUsers()
        {
            var AddedUserItems = _repository.GetAllAddedUsers();
            return Ok(_mapper.Map<IEnumerable<AddedUserReadDto>>(AddedUserItems));
        }

        [HttpGet("{id}", Name = "GetAddedUserById")]
        public ActionResult<AddedUserReadDto> GetAddedUserById(int id)
        {
            var AddedUserItem = _repository.GetAddedUserById(id);
            if (AddedUserItem != null)
                return Ok(_mapper.Map<AddedUserReadDto>(AddedUserItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<AddedUserReadDto> CreateAddedUser(AddedUserCreateDto AddedUserCreateDto)
        {
            var AddedUserModel = _mapper.Map<AddedUser>(AddedUserCreateDto);
            _repository.CreateAddedUser(AddedUserModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<AddedUserReadDto>(AddedUserModel);
            return CreatedAtRoute(nameof(GetAddedUserById), new {ID = outPut.AddedUserID}, outPut);
            //return Ok(_mapper.Map<CompanyReadDto>(CompanyModel));
        }

        [HttpPut]
        public ActionResult UpdateAddedUser(AddedUserUpdateDto AddedUserUpdateDto)
        {
            var AddedUserModel = _repository.GetAddedUserById(AddedUserUpdateDto.AddedUserID);
            if (AddedUserModel == null) return NotFound();
            _mapper.Map(AddedUserUpdateDto, AddedUserModel);
            _repository.UpdateAddedUser(AddedUserModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAddedUser(int id)
        {
            var AddedUserToDelete = _repository.GetAddedUserById(id);
            _repository.DeleteAddedUser(AddedUserToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}