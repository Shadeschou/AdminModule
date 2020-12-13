using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Qdea.API.Data;
using System.Collections.Generic;
using DataLayer.Dtos;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/tagideas")]
    [ApiController]
    public class TagIdeasController : ControllerBase
    {
        private readonly ITagIdeas _repository;
        private readonly IMapper _mapper;

        public TagIdeasController(ITagIdeas repository, IMapper mapper)
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
            {
                return Ok(_mapper.Map<TagIdeaReadDto>(TagIdeaItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<TagIdeaReadDto> CreateTagIdea(TagIdeaCreateDto TagIdeaCreateDto)
        {
            var TagIdeaModel = _mapper.Map<TagIdea>(TagIdeaCreateDto);
            _repository.CreateTagIdea(TagIdeaModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<TagIdeaReadDto>(TagIdeaModel);
            return CreatedAtRoute(nameof(GetTagIdeaById), new { ID = outPut.TagListID }, outPut);
            //return Ok(_mapper.Map<TagIdeaReadDto>(TagIdeaModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTagIdea(int id, TagIdeaUpdateDto tagIdeaUpdateDto)
        {
            var tagIdeaModel = _repository.GetTagIdeaById(id);
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