using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Qdea.API.Data;
using Qdea.API.Domain;
using DataLayer.Dtos;

namespace Qdea.API.Controllers
{
    [Route("api/ideainteractiontypes")]
    [ApiController]
    public class IdeaInteractionTypesController : ControllerBase
    {
        private readonly IIdeaInteractionType _repository;
        private readonly IMapper _mapper;

        public IdeaInteractionTypesController(IIdeaInteractionType repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IdeaInteractionTypeReadDto>> GetAllIdeaInteractionTypes()
        {
            var IdeaInteractionTypeItems = _repository.GetAllIdeaInteractionTypes();
            return Ok(_mapper.Map<IEnumerable<IdeaInteractionTypeReadDto>>(IdeaInteractionTypeItems));
        }

        [HttpGet("{id}", Name = "GetIdeaInteractionTypeById")]
        public ActionResult<IdeaInteractionTypeReadDto> GetIdeaInteractionTypeById(int id)
        {
            var IdeaInteractionTypeItem = _repository.GetIdeaInteractionTypeById(id);
            if (IdeaInteractionTypeItem != null)
            {
                return Ok(_mapper.Map<IdeaInteractionTypeReadDto>(IdeaInteractionTypeItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<IdeaInteractionTypeReadDto> CreateIdeaInteractionType(IdeaInteractionTypeCreateDto IdeaInteractionTypeCreateDto)
        {
            var IdeaInteractionTypeModel = _mapper.Map<IdeaInteractionType>(IdeaInteractionTypeCreateDto);
            _repository.CreateIdeaInteractionType(IdeaInteractionTypeModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<IdeaInteractionTypeReadDto>(IdeaInteractionTypeModel);
            return CreatedAtRoute(nameof(GetIdeaInteractionTypeById), new { ID = outPut.IdeaInteractionTypeID }, outPut);
            //return Ok(_mapper.Map<CompanyReadDto>(CompanyModel));
        }

        [HttpPut]
        public ActionResult UpdateIdeaInteractionType(IdeaInteractionTypeUpdateDto IdeaInteractionTypeUpdateDto)
        {
            var IdeaInteractionTypeModel = _repository.GetIdeaInteractionTypeById(IdeaInteractionTypeUpdateDto.IdeaInteractionTypeID);
            if (IdeaInteractionTypeModel == null) return NotFound();
            _mapper.Map(IdeaInteractionTypeUpdateDto, IdeaInteractionTypeModel);
            _repository.UpdateIdeaInteractionType(IdeaInteractionTypeModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteIdeaInteractionType(int id)
        {
            var IdeaInteractionTypeToDelete = _repository.GetIdeaInteractionTypeById(id);
            _repository.DeleteIdeaInteractionType(IdeaInteractionTypeToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}