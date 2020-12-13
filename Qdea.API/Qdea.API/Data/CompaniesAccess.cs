using System;
using System.Linq;
using Qdea.API.Domain;
using System.Collections.Generic;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface ICompanies
    {
        bool SaveChanges();

        IEnumerable<Company> GetAllCompanies();
        Company GetCompanyById(int id);
        void CreateCompany(Company Company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
    }

    public class CompaniesAccess : ICompanies
    {
        private readonly DatabaseContext _access;

        public CompaniesAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateCompany(Company cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.Companies.Add(cmd);
        }

        public void DeleteCompany(Company company)
        {
            _access.Remove(company);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _access.Companies.ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _access.Companies.FirstOrDefault(p => p.CompanyID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdateCompany(Company company)
        {
            _access.Update(company);
        }
    }
}