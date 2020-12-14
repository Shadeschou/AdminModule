using System;
using System.Linq;
using System.Collections.Generic;
using Qdea.API.Domain;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IImpact
    {
        bool SaveChanges();

        IEnumerable<Impact> GetAllImpacts();
        Impact GetImpactById(int id);
        void CreateImpact(Impact Impact);
        void UpdateImpact(Impact Impact);
        void DeleteImpact(Impact Impact);
    }

    public class ImpactsAccess : IImpact
    {
        private readonly DatabaseContext _access;

        public ImpactsAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateImpact(Impact cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.Impacts.Add(cmd);
        }

        public void DeleteImpact(Impact Impact)
        {
            _access.Remove(Impact);
        }

        public IEnumerable<Impact> GetAllImpacts()
        {
            return _access.Impacts.ToList();
        }

        public Impact GetImpactById(int id)
        {
            return _access.Impacts.FirstOrDefault(p => p.ImpactID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdateImpact(Impact Impact)
        {
            _access.Update(Impact);
        }
    }
}