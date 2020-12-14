using System;
using System.Linq;
using Qdea.Back.Domain;
using System.Collections.Generic;
using Qdea.Back.Models;

namespace Qdea.Back.Data
{
    public interface IPriority
    {
        bool SaveChanges();

        IEnumerable<Priority> GetAllPriorities();
        Priority GetPriorityById(int id);
        void CreatePriority(Priority priority);
        void UpdatePriority(Priority priority);
        void DeletePriority(Priority priority);
    }

    public class PrioritiesAccess : IPriority
    {
        private readonly DatabaseContext _access;

        public PrioritiesAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreatePriority(Priority cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.Priorities.Add(cmd);
        }

        public void DeletePriority(Priority priority)
        {
            _access.Remove(priority);
        }

        public IEnumerable<Priority> GetAllPriorities()
        {
            return _access.Priorities.ToList();
        }

        public Priority GetPriorityById(int id)
        {
            return _access.Priorities.FirstOrDefault(p => p.PriorityID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdatePriority(Priority priority)
        {
            _access.Update(priority);
        }
    }
}