using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Qdea.API.Data;
using Qdea.API.Domain;
using DataLayer.Dtos;

namespace Qdea.API.Controllers
{
    [Route("api/ideainteractions")]
    [ApiController]
    public class IdeaInteractionsController : ControllerBase
    {
        private readonly IIdeaInteraction _repository;
        private readonly IMapper _mapper;

        public IdeaInteractionsController(IIdeaInteraction repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IdeaInteractionReadDto>> GetAllIdeaInteractions()
        {
            var IdeaInteractionItems = _repository.GetAllIdeaInteractions();
            return Ok(_mapper.Map<IEnumerable<IdeaInteractionReadDto>>(IdeaInteractionItems));
        }

        [HttpGet("{id}", Name = "GetIdeaInteractionById")]
        public ActionResult<IdeaInteractionReadDto> GetIdeaInteractionById(int id)
        {
            var IdeaInteractionItem = _repository.GetIdeaInteractionById(id);
            if (IdeaInteractionItem != null)
            {
                return Ok(_mapper.Map<IdeaInteractionReadDto>(IdeaInteractionItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<IdeaInteractionReadDto> CreateIdeaInteraction(IdeaInteractionCreateDto IdeaInteractionCreateDto)
        {
            var IdeaInteractionModel = _mapper.Map<IdeaInteraction>(IdeaInteractionCreateDto);
            _repository.CreateIdeaInteraction(IdeaInteractionModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<IdeaInteractionReadDto>(IdeaInteractionModel);
            return CreatedAtRoute(nameof(GetIdeaInteractionById), new { ID = outPut.IdeaInteractionID }, outPut);
            //return Ok(_mapper.Map<CompanyReadDto>(CompanyModel));
        }

        [HttpPut]
        public ActionResult UpdateIdeaInteraction(IdeaInteractionUpdateDto IdeaInteractionUpdateDto)
        {
            var IdeaInteractionModel = _repository.GetIdeaInteractionById(IdeaInteractionUpdateDto.IdeaInteractionID);
            if (IdeaInteractionModel == null) return NotFound();
            _mapper.Map(IdeaInteractionUpdateDto, IdeaInteractionModel);
            _repository.UpdateIdeaInteraction(IdeaInteractionModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteIdeaInteraction(int id)
        {
            var IdeaInteractionToDelete = _repository.GetIdeaInteractionById(id);
            _repository.DeleteIdeaInteraction(IdeaInteractionToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}