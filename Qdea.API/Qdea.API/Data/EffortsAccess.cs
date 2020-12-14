using System;
using System.Linq;
using System.Collections.Generic;
using Qdea.API.Domain;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IEffort
    {
        bool SaveChanges();

        IEnumerable<Effort> GetAllEfforts();
        Effort GetEffortById(int id);
        void CreateEffort(Effort Effort);
        void UpdateEffort(Effort Effort);
        void DeleteEffort(Effort Effort);
    }

    public class EffortsAccess : IEffort
    {
        private readonly DatabaseContext _access;

        public EffortsAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateEffort(Effort cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.Efforts.Add(cmd);
        }

        public void DeleteEffort(Effort Effort)
        {
            _access.Remove(Effort);
        }

        public IEnumerable<Effort> GetAllEfforts()
        {
            return _access.Efforts.ToList();
        }

        public Effort GetEffortById(int id)
        {
            return _access.Efforts.FirstOrDefault(p => p.EffortID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdateEffort(Effort Effort)
        {
            _access.Update(Effort);
        }
    }
}