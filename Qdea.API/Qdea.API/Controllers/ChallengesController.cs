using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Qdea.API.Data;
using System.Collections.Generic;
using DataLayer.Dtos;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/challenges")]
    [ApiController]
    public class ChallengesController : ControllerBase
    {
        private readonly IChallenges _repository;
        private readonly IMapper _mapper;

        public ChallengesController(IChallenges repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ChallengeReadDto>> GetAllChallenges()
        {
            var challengeItems = _repository.GetAllChallenges();
            return Ok(_mapper.Map<IEnumerable<ChallengeReadDto>>(challengeItems));
        }

        [HttpGet("{id}", Name = "GetChallengeById")]
        public ActionResult<ChallengeReadDto> GetChallengeById(int id)
        {
            var ChallengeItem = _repository.GetChallengeById(id);
            if (ChallengeItem != null)
            {
                return Ok(_mapper.Map<ChallengeReadDto>(ChallengeItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<ChallengeReadDto> CreateChallenge(ChallengeCreateDto challengeCreateDto)
        {
            var challengeModel = _mapper.Map<Challenge>(challengeCreateDto);
            _repository.CreateChallenge(challengeModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<ChallengeReadDto>(challengeModel);
            return CreatedAtRoute(nameof(GetChallengeById), new { ID = outPut.ChallengeID }, outPut);
            //return Ok(_mapper.Map<ChallengeReadDto>(challengeModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateChallenge(int id, ChallengeUpdateDto challengeUpdateDto)
        {
            var challengeModel = _repository.GetChallengeById(id);
            if (challengeModel == null) return NotFound();
            _mapper.Map(challengeUpdateDto, challengeModel);
            _repository.UpdateChallenge(challengeModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteChallenge(int id)
        {
            var challengeToDelete = _repository.GetChallengeById(id);
            _repository.DeleteChallenge(challengeToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}