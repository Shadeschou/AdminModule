using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Qdea.API.Data;
using System.Collections.Generic;
using DataLayer.Dtos;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/costsavings")]
    [ApiController]
    public class CostSavingsController : ControllerBase
    {
        private readonly ICostSavings _repository;
        private readonly IMapper _mapper;

        public CostSavingsController(ICostSavings repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CostSavingReadDto>> GetAllCostSavings()
        {
            var CostSavingItems = _repository.GetAllCostSavings();
            return Ok(_mapper.Map<IEnumerable<CostSavingReadDto>>(CostSavingItems));
        }

        [HttpGet("{id}", Name = "GetCostSavingById")]
        public ActionResult<CostSavingReadDto> GetCostSavingById(int id)
        {
            var CostSavingItem = _repository.GetCostSavingById(id);
            if (CostSavingItem != null)
            {
                return Ok(_mapper.Map<CostSavingReadDto>(CostSavingItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<CostSavingReadDto> CreateCostSaving(CostSavingCreateDto CostSavingCreateDto)
        {
            var CostSavingModel = _mapper.Map<CostSaving>(CostSavingCreateDto);
            _repository.CreateCostSaving(CostSavingModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<CostSavingReadDto>(CostSavingModel);
            return CreatedAtRoute(nameof(GetCostSavingById), new { ID = outPut.CostSavingID }, outPut);
            //return Ok(_mapper.Map<CostSavingReadDto>(CostSavingModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCostSaving(int id, CostSavingUpdateDto costSavingUpdateDto)
        {
            var costSavingModel = _repository.GetCostSavingById(id);
            if (costSavingModel == null) return NotFound();
            _mapper.Map(costSavingUpdateDto, costSavingModel);
            _repository.UpdateCostSaving(costSavingModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCostSaving(int id)
        {
            var CostSavingToDelete = _repository.GetCostSavingById(id);
            _repository.DeleteCostSaving(CostSavingToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}