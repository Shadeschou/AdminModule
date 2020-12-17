using System;
using System.Collections.Generic;
using System.Linq;
using Qdea.API.Domain;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IIdeaInteraction
    {
        bool SaveChanges();

        IEnumerable<IdeaInteraction> GetAllIdeaInteractions();
        IdeaInteraction GetIdeaInteractionById(int id);
        void CreateIdeaInteraction(IdeaInteraction IdeaInteraction);
        void UpdateIdeaInteraction(IdeaInteraction IdeaInteraction);
        void DeleteIdeaInteraction(IdeaInteraction IdeaInteraction);
    }

    public class IdeaInteractionsAccess : IIdeaInteraction
    {
        private readonly DatabaseContext _access;

        public IdeaInteractionsAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateIdeaInteraction(IdeaInteraction cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));

            _access.IdeaInteractions.Add(cmd);
        }

        public void DeleteIdeaInteraction(IdeaInteraction IdeaInteraction)
        {
            _access.Remove(IdeaInteraction);
        }

        public IEnumerable<IdeaInteraction> GetAllIdeaInteractions()
        {
            return _access.IdeaInteractions.ToList();
        }

        public IdeaInteraction GetIdeaInteractionById(int id)
        {
            return _access.IdeaInteractions.FirstOrDefault(p => p.IdeaInteractionID == id);
        }

        public bool SaveChanges()
        {
            return _access.SaveChanges() >= 0;
        }

        public void UpdateIdeaInteraction(IdeaInteraction IdeaInteraction)
        {
            _access.Update(IdeaInteraction);
        }
    }
}