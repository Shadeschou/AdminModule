using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Qdea.API.Data;
using System.Collections.Generic;
using DataLayer.Dtos;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/userideas")]
    [ApiController]
    public class UserIdeasController : ControllerBase
    {
        private readonly IUserIdeas _repository;
        private readonly IMapper _mapper;

        public UserIdeasController(IUserIdeas repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserIdeaReadDto>> GetAllUserIdeas()
        {
            var UserIdeaItems = _repository.GetAllUserIdeas();
            return Ok(_mapper.Map<IEnumerable<UserIdeaReadDto>>(UserIdeaItems));
        }

        [HttpGet("{id}", Name = "GetUserIdeaById")]
        public ActionResult<UserIdeaReadDto> GetUserIdeaById(int id)
        {
            var UserIdeaItem = _repository.GetUserIdeaById(id);
            if (UserIdeaItem != null)
            {
                return Ok(_mapper.Map<UserIdeaReadDto>(UserIdeaItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<UserIdeaReadDto> CreateUserIdea(UserIdeaCreateDto UserIdeaCreateDto)
        {
            var UserIdeaModel = _mapper.Map<UserIdea>(UserIdeaCreateDto);
            _repository.CreateUserIdea(UserIdeaModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<UserIdeaReadDto>(UserIdeaModel);
            return CreatedAtRoute(nameof(GetUserIdeaById), new { ID = outPut.UserIdeaID }, outPut);
            //return Ok(_mapper.Map<UserIdeaReadDto>(UserIdeaModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUserIdea(int id, UserIdeaUpdateDto userIdeaUpdateDto)
        {
            var userIdeaModel = _repository.GetUserIdeaById(id);
            if (userIdeaModel == null) return NotFound();
            _mapper.Map(userIdeaUpdateDto, userIdeaModel);
            _repository.UpdateUserIdea(userIdeaModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUserIdea(int id)
        {
            var UserIdeaToDelete = _repository.GetUserIdeaById(id);
            _repository.DeleteUserIdea(UserIdeaToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}