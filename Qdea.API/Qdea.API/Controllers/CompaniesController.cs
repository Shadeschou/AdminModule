using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Qdea.API.Data;
using System.Collections.Generic;
using DataLayer.Dtos;
using Qdea.API.Domain;

namespace Qdea.API.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanies _repository;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanies repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompanyReadDto>> GetAllCompanies()
        {
            var CompanyItems = _repository.GetAllCompanies();
            return Ok(_mapper.Map<IEnumerable<CompanyReadDto>>(CompanyItems));
        }

        [HttpGet("{id}", Name = "GetCompanyById")]
        public ActionResult<CompanyReadDto> GetCompanyById(int id)
        {
            var CompanyItem = _repository.GetCompanyById(id);
            if (CompanyItem != null)
            {
                return Ok(_mapper.Map<CompanyReadDto>(CompanyItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<CompanyReadDto> CreateCompany(CompanyCreateDto CompanyCreateDto)
        {
            var CompanyModel = _mapper.Map<Company>(CompanyCreateDto);
            _repository.CreateCompany(CompanyModel);
            _repository.SaveChanges();
            var outPut = _mapper.Map<CompanyReadDto>(CompanyModel);
            return CreatedAtRoute(nameof(GetCompanyById), new { ID = outPut.CompanyID }, outPut);
            //return Ok(_mapper.Map<CompanyReadDto>(CompanyModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCompany(int id, CompanyUpdateDto companyUpdateDto)
        {
            var companyModel = _repository.GetCompanyById(id);
            if (companyModel == null) return NotFound();
            _mapper.Map(companyUpdateDto, companyModel);
            _repository.UpdateCompany(companyModel);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCompany(int id)
        {
            var CompanyToDelete = _repository.GetCompanyById(id);
            _repository.DeleteCompany(CompanyToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}