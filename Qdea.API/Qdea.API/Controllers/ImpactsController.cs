using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Qdea.API.Data;
using Qdea.API.Domain;
using DataLayer.Dtos;

namespace Qdea.API.Controllers
{
    [Route("api/impactss")]
    [ApiController]
    public class ImpactsController : ControllerBase
    {
        private readonly IImpact _repository;
        private readonly IMapper _mapper;

        public ImpactsController(IImpact repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ImpactReadDto>> GetAllImpacts()
        {
            var ImpactItems = _repository.GetAllImpacts();
            return Ok(_mapper.Map<IEnumerable<ImpactReadDto>>(ImpactItems));
        }

        [HttpGet("{id}", Name = "GetImpactById")]
        public ActionResult<ImpactReadDto> GetImpactById(int id)
        {
            var ImpactItem = _repository.GetImpactById(id);
            if (ImpactItem != null)
            {
                return Ok(_mapper.Map<ImpactReadDto>(ImpactItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<ImpactReadDto> CreateImpact(ImpactCreateDto ImpactCreateDto)
        {
            var ImpactModel = _mapper.Map<Impact>(ImpactCreateDto);
            _repository.CreateImpact(ImpactModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<ImpactReadDto>(ImpactModel);
            return CreatedAtRoute(nameof(GetImpactById), new { ID = outPut.ImpactID }, outPut);
            //return Ok(_mapper.Map<CompanyReadDto>(CompanyModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateImpact(int id, ImpactUpdateDto ImpactUpdateDto)
        {
            var ImpactModel = _repository.GetImpactById(id);
            if (ImpactModel == null) return NotFound();
            _mapper.Map(ImpactUpdateDto, ImpactModel);
            _repository.UpdateImpact(ImpactModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteImpact(int id)
        {
            var ImpactToDelete = _repository.GetImpactById(id);
            _repository.DeleteImpact(ImpactToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}