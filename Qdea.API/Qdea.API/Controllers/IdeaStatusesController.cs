using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Qdea.API.Data;
using System.Collections.Generic;
using DataLayer.Dtos;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/ideastatuses")]
    [ApiController]
    public class IdeaStatusesController : ControllerBase
    {
        private readonly IIdeaStatuses _repository;
        private readonly IMapper _mapper;

        public IdeaStatusesController(IIdeaStatuses repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IdeaStatusReadDto>> GetAllIdeaStatuses()
        {
            var IdeaStatusItems = _repository.GetAllIdeaStatuses();
            return Ok(_mapper.Map<IEnumerable<IdeaStatusReadDto>>(IdeaStatusItems));
        }

        [HttpGet("{id}", Name = "GetIdeaStatusById")]
        public ActionResult<IdeaStatusReadDto> GetIdeaStatusById(int id)
        {
            var IdeaStatusItem = _repository.GetIdeaStatusById(id);
            if (IdeaStatusItem != null)
            {
                return Ok(_mapper.Map<IdeaStatusReadDto>(IdeaStatusItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<IdeaStatusReadDto> CreateIdeaStatus(IdeaStatusCreateDto IdeaStatusCreateDto)
        {
            var IdeaStatusModel = _mapper.Map<IdeaStatus>(IdeaStatusCreateDto);
            _repository.CreateIdeaStatus(IdeaStatusModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<IdeaStatusReadDto>(IdeaStatusModel);
            return CreatedAtRoute(nameof(GetIdeaStatusById), new { ID = outPut.IdeaStatusID }, outPut);
            //return Ok(_mapper.Map<IdeaStatusReadDto>(IdeaStatusModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateIdeaStatus(int id, IdeaStatusUpdateDto ideaStatusUpdateDto)
        {
            var ideaStatusModel = _repository.GetIdeaStatusById(id);
            if (ideaStatusModel == null) return NotFound();
            _mapper.Map(ideaStatusUpdateDto, ideaStatusModel);
            _repository.UpdateIdeaStatus(ideaStatusModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteIdeaStatus(int id)
        {
            var IdeaStatusToDelete = _repository.GetIdeaStatusById(id);
            _repository.DeleteIdeaStatus(IdeaStatusToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}