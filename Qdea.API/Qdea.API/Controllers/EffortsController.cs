using System.Collections.Generic;
using AutoMapper;
using DataLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using Qdea.API.Data;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/efforts")]
    [ApiController]
    public class EffortsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEffort _repository;

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
                return Ok(_mapper.Map<EffortReadDto>(EffortItem));
            return NotFound();
        }

        [HttpPost]
        public ActionResult<EffortReadDto> CreateEffort(EffortCreateDto EffortCreateDto)
        {
            var EffortModel = _mapper.Map<Effort>(EffortCreateDto);
            _repository.CreateEffort(EffortModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<EffortReadDto>(EffortModel);
            return CreatedAtRoute(nameof(GetEffortById), new {ID = outPut.EffortID}, outPut);
            //return Ok(_mapper.Map<CompanyReadDto>(CompanyModel));
        }

        [HttpPut]
        public ActionResult UpdateEffort(EffortUpdateDto EffortUpdateDto)
        {
            var EffortModel = _repository.GetEffortById(EffortUpdateDto.EffortID);
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