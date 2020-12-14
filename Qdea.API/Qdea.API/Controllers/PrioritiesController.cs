using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Qdea.Back.Dtos;
using Qdea.Back.Data;
using System.Collections.Generic;
using Qdea.Back.Domain;

namespace Qdea.Back.Controllers
{
    [Route("api/priorities")]
    [ApiController]
    public class PrioritiesController : ControllerBase
    {
        private readonly IPriority _repository;
        private readonly IMapper _mapper;

        public PrioritiesController(IPriority repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PriorityReadDto>> GetAllPriorities()
        {
            var PriorityItems = _repository.GetAllPriorities();
            return Ok(_mapper.Map<IEnumerable<PriorityReadDto>>(PriorityItems));
        }

        [HttpGet("{id}", Name = "GetPriorityById")]
        public ActionResult<PriorityReadDto> GetPriorityById(int id)
        {
            var PriorityItem = _repository.GetPriorityById(id);
            if (PriorityItem != null)
            {
                return Ok(_mapper.Map<PriorityReadDto>(PriorityItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<PriorityReadDto> CreatePriority(PriorityCreateDto PriorityCreateDto)
        {
            var PriorityModel = _mapper.Map<Priority>(PriorityCreateDto);
            _repository.CreatePriority(PriorityModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<PriorityReadDto>(PriorityModel);
            return CreatedAtRoute(nameof(GetPriorityById), new { ID = outPut.PriorityID }, outPut);
            //return Ok(_mapper.Map<PriorityReadDto>(PriorityModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePriority(int id, PriorityUpdateDto priorityUpdateDto)
        {
            var priorityModel = _repository.GetPriorityById(id);
            if (priorityModel == null) return NotFound();
            _mapper.Map(priorityUpdateDto, priorityModel);
            _repository.UpdatePriority(priorityModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePriority(int id)
        {
            var PriorityToDelete = _repository.GetPriorityById(id);
            _repository.DeletePriority(PriorityToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}