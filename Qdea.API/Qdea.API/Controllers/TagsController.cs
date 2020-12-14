using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Qdea.Back.Dtos;
using Qdea.Back.Data;
using System.Collections.Generic;
using Qdea.Back.Domain;

namespace Qdea.Back.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITag _repository;
        private readonly IMapper _mapper;

        public TagsController(ITag repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TagReadDto>> GetAllTags()
        {
            var TagItems = _repository.GetAllTags();
            return Ok(_mapper.Map<IEnumerable<TagReadDto>>(TagItems));
        }

        [HttpGet("{id}", Name = "GetTagById")]
        public ActionResult<TagReadDto> GetTagById(int id)
        {
            var TagItem = _repository.GetTagById(id);
            if (TagItem != null)
            {
                return Ok(_mapper.Map<TagReadDto>(TagItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<TagReadDto> CreateTag(TagCreateDto TagCreateDto)
        {
            var TagModel = _mapper.Map<Tag>(TagCreateDto);
            _repository.CreateTag(TagModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<TagReadDto>(TagModel);
            return CreatedAtRoute(nameof(GetTagById), new { ID = outPut.TagID }, outPut);
            //return Ok(_mapper.Map<TagReadDto>(TagModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTag(int id, TagUpdateDto tagUpdateDto)
        {
            var tagModel = _repository.GetTagById(id);
            if (tagModel == null) return NotFound();
            _mapper.Map(tagUpdateDto, tagModel);
            _repository.UpdateTag(tagModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTag(int id)
        {
            var TagToDelete = _repository.GetTagById(id);
            _repository.DeleteTag(TagToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}