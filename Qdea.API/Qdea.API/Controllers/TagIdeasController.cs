using System.Collections.Generic;
using AutoMapper;
using DataLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using Qdea.API.Data;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/tagideas")]
    [ApiController]
    public class TagIdeasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITagIdea _repository;

        public TagIdeasController(ITagIdea repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TagIdeaReadDto>> GetAllTagIdeas()
        {
            var TagIdeaItems = _repository.GetAllTagIdeas();
            return Ok(_mapper.Map<IEnumerable<TagIdeaReadDto>>(TagIdeaItems));
        }

        [HttpGet("{id}", Name = "GetTagIdeaById")]
        public ActionResult<TagIdeaReadDto> GetTagIdeaById(int id)
        {
            var TagIdeaItem = _repository.GetTagIdeaById(id);
            if (TagIdeaItem != null)
                return Ok(_mapper.Map<TagIdeaReadDto>(TagIdeaItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<TagIdeaReadDto> CreateTagIdea(TagIdeaCreateDto TagIdeaCreateDto)
        {
            var TagIdeaModel = _mapper.Map<TagIdea>(TagIdeaCreateDto);
            _repository.CreateTagIdea(TagIdeaModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<TagIdeaReadDto>(TagIdeaModel);
            return CreatedAtRoute(nameof(GetTagIdeaById), new {ID = outPut.TagListID}, outPut);
            //return Ok(_mapper.Map<TagIdeaReadDto>(TagIdeaModel));
        }

        [HttpPut]
        public ActionResult UpdateTagIdea(TagIdeaUpdateDto tagIdeaUpdateDto)
        {
            var tagIdeaModel = _repository.GetTagIdeaById(tagIdeaUpdateDto.IdeaID);
            if (tagIdeaModel == null) return NotFound();
            _mapper.Map(tagIdeaUpdateDto, tagIdeaModel);
            _repository.UpdateTagIdea(tagIdeaModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTagIdea(int id)
        {
            var TagIdeaToDelete = _repository.GetTagIdeaById(id);
            _repository.DeleteTagIdea(TagIdeaToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}