using System;
using System.Linq;
using Qdea.API.Domain;
using System.Collections.Generic;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface ICostSavings
    {
        bool SaveChanges();

        IEnumerable<CostSaving> GetAllCostSavings();
        CostSaving GetCostSavingById(int id);
        void CreateCostSaving(CostSaving costSaving);
        void UpdateCostSaving(CostSaving costSaving);
        void DeleteCostSaving(CostSaving costSaving);
    }

    public class CostSavingsAccess : ICostSavings
    {
        private readonly DatabaseContext _access;

        public CostSavingsAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateCostSaving(CostSaving cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.CostSavings.Add(cmd);
        }

        public void DeleteCostSaving(CostSaving costSaving)
        {
            _access.Remove(costSaving);
        }

        public IEnumerable<CostSaving> GetAllCostSavings()
        {
            return _access.CostSavings.ToList();
        }

        public CostSaving GetCostSavingById(int id)
        {
            return _access.CostSavings.FirstOrDefault(p => p.CostSavingID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdateCostSaving(CostSaving costSaving)
        {
            _access.Update(costSaving);
        }
    }
}