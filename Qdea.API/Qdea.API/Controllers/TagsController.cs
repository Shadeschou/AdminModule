using System.Collections.Generic;
using AutoMapper;
using DataLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using Qdea.API.Data;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITag _repository;

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
                return Ok(_mapper.Map<TagReadDto>(TagItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<TagReadDto> CreateTag(TagCreateDto TagCreateDto)
        {
            var TagModel = _mapper.Map<Tag>(TagCreateDto);
            _repository.CreateTag(TagModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<TagReadDto>(TagModel);
            return CreatedAtRoute(nameof(GetTagById), new {ID = outPut.TagID}, outPut);
            //return Ok(_mapper.Map<TagReadDto>(TagModel));
        }

        [HttpPut]
        public ActionResult UpdateTag(TagUpdateDto tagUpdateDto)
        {
            var tagModel = _repository.GetTagById(tagUpdateDto.TagID);
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