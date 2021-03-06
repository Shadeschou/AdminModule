using System.Collections.Generic;
using AutoMapper;
using DataLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using Qdea.API.Data;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/ideas")]
    [ApiController]
    public class IdeasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIdea _repository;

        public IdeasController(IIdea repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IdeaReadDto>> GetAllIdeas()
        {
            var ideaItems = _repository.GetAllIdeas();
            return Ok(_mapper.Map<IEnumerable<IdeaReadDto>>(ideaItems));
        }

        [HttpGet("{id}", Name = "GetIdeaById")]
        public ActionResult<IdeaReadDto> GetIdeaById(int id)
        {
            var IdeaItem = _repository.GetIdeaById(id);
            if (IdeaItem != null)
                return Ok(_mapper.Map<IdeaReadDto>(IdeaItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<IdeaReadDto> CreateIdea(IdeaCreateDto ideaCreateDto)
        {
            var IdeaModel = _mapper.Map<Idea>(ideaCreateDto);
            _repository.CreateIdea(IdeaModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<IdeaReadDto>(IdeaModel);
            return CreatedAtRoute(nameof(GetIdeaById), new {ID = outPut.IdeaID}, outPut);
            //return Ok(_mapper.Map<IdeaReadDto>(IdeaModel));
        }

        [HttpPut]
        public ActionResult UpdateIdea(IdeaUpdateDto ideaUpdateDto)
        {
            var ideaModel = _repository.GetIdeaById(ideaUpdateDto.IdeaID);
            if (ideaModel == null) return NotFound();
            _mapper.Map(ideaUpdateDto, ideaModel);
            _repository.UpdateIdea(ideaModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteIdea(int id)
        {
            var ideaToDelete = _repository.GetIdeaById(id);
            _repository.DeleteIdea(ideaToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}