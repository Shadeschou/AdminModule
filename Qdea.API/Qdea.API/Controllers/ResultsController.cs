using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Qdea.API.Data;
using System.Collections.Generic;
using DataLayer.Dtos;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/results")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResults _repository;
        private readonly IMapper _mapper;

        public ResultsController(IResults repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ResultReadDto>> GetAllResults()
        {
            var ResultItems = _repository.GetAllResults();
            return Ok(_mapper.Map<IEnumerable<ResultReadDto>>(ResultItems));
        }

        [HttpGet("{id}", Name = "GetResultById")]
        public ActionResult<ResultReadDto> GetResultById(int id)
        {
            var ResultItem = _repository.GetResultById(id);
            if (ResultItem != null)
            {
                return Ok(_mapper.Map<ResultReadDto>(ResultItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<ResultReadDto> CreateResult(ResultCreateDto ResultCreateDto)
        {
            var ResultModel = _mapper.Map<Result>(ResultCreateDto);
            _repository.CreateResult(ResultModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<ResultReadDto>(ResultModel);
            return CreatedAtRoute(nameof(GetResultById), new { ID = outPut.ResultID }, outPut);
            //return Ok(_mapper.Map<ResultReadDto>(ResultModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateResult(int id, ResultUpdateDto resultUpdateDto)
        {
            var resultModel = _repository.GetResultById(id);
            if (resultModel == null) return NotFound();
            _mapper.Map(resultUpdateDto, resultModel);
            _repository.UpdateResult(resultModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteResult(int id)
        {
            var ResultToDelete = _repository.GetResultById(id);
            _repository.DeleteResult(ResultToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}