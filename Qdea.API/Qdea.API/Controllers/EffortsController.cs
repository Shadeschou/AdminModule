using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Qdea.Back.Dtos;
using Qdea.Back.Data;
using System.Collections.Generic;
using Qdea.Back.Domain;

namespace Qdea.Back.Controllers
{
    [Route("api/efforts")]
    [ApiController]
    public class EffortsController : ControllerBase
    {
        private readonly IEffort _repository;
        private readonly IMapper _mapper;

        public EffortsController(IEffort repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EffortReadDto>> GetAllEfforts()
        {
            var EffortItems = _repository.GetAllEfforts();
            return Ok(_mapper.Map<IEnumerable<EffortReadDto>>(EffortItems));
        }

        [HttpGet("{id}", Name = "GetEffortById")]
        public ActionResult<EffortReadDto> GetEffortById(int id)
        {
            var EffortItem = _repository.GetEffortById(id);
            if (EffortItem != null)
            {
                return Ok(_mapper.Map<EffortReadDto>(EffortItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<EffortReadDto> CreateEffort(EffortCreateDto EffortCreateDto)
        {
            var EffortModel = _mapper.Map<Effort>(EffortCreateDto);
            _repository.CreateEffort(EffortModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<EffortReadDto>(EffortModel);
            return CreatedAtRoute(nameof(GetEffortById), new { ID = outPut.EffortID }, outPut);
            //return Ok(_mapper.Map<CompanyReadDto>(CompanyModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEffort(int id, EffortUpdateDto EffortUpdateDto)
        {
            var EffortModel = _repository.GetEffortById(id);
            if (EffortModel == null) return NotFound();
            _mapper.Map(EffortUpdateDto, EffortModel);
            _repository.UpdateEffort(EffortModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEffort(int id)
        {
            var EffortToDelete = _repository.GetEffortById(id);
            _repository.DeleteEffort(EffortToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}