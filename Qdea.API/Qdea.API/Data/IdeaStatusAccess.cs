using System;
using System.Collections.Generic;
using System.Linq;
using Qdea.API.Domain;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IIdeaStatus
    {
        bool SaveChanges();

        IEnumerable<IdeaStatus> GetAllIdeaStatuses();
        IdeaStatus GetIdeaStatusById(int id);
        void CreateIdeaStatus(IdeaStatus ideaStatus);
        void UpdateIdeaStatus(IdeaStatus ideaStatus);
        void DeleteIdeaStatus(IdeaStatus ideaStatus);
    }

    public class IdeaStatusAccess : IIdeaStatus
    {
        private readonly DatabaseContext _access;

        public IdeaStatusAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateIdeaStatus(IdeaStatus cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));

            _access.IdeaStatuses.Add(cmd);
        }

        public void DeleteIdeaStatus(IdeaStatus ideaStatus)
        {
            _access.Remove(ideaStatus);
        }

        public IEnumerable<IdeaStatus> GetAllIdeaStatuses()
        {
            return _access.IdeaStatuses.ToList();
        }

        public IdeaStatus GetIdeaStatusById(int id)
        {
            return _access.IdeaStatuses.FirstOrDefault(p => p.IdeaStatusID == id);
        }

        public bool SaveChanges()
        {
            return _access.SaveChanges() >= 0;
        }

        public void UpdateIdeaStatus(IdeaStatus ideaStatus)
        {
            _access.Update(ideaStatus);
        }
    }
}