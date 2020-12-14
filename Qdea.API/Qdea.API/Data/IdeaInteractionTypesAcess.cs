using System;
using System.Linq;
using System.Collections.Generic;
using Qdea.API.Domain;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IIdeaInteractionType
    {
        bool SaveChanges();

        IEnumerable<IdeaInteractionType> GetAllIdeaInteractionTypes();
        IdeaInteractionType GetIdeaInteractionTypeById(int id);
        void CreateIdeaInteractionType(IdeaInteractionType IdeaInteractionType);
        void UpdateIdeaInteractionType(IdeaInteractionType company);
        void DeleteIdeaInteractionType(IdeaInteractionType IdeaInteractionType);
    }

    public class IdeaInteractionTypesAccess : IIdeaInteractionType
    {
        private readonly DatabaseContext _access;

        public IdeaInteractionTypesAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateIdeaInteractionType(IdeaInteractionType cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.IdeaInteractionTypes.Add(cmd);
        }

        public void DeleteIdeaInteractionType(IdeaInteractionType IdeaInteractionType)
        {
            _access.Remove(IdeaInteractionType);
        }

        public IEnumerable<IdeaInteractionType> GetAllIdeaInteractionTypes()
        {
            return _access.IdeaInteractionTypes.ToList();
        }

        public IdeaInteractionType GetIdeaInteractionTypeById(int id)
        {
            return _access.IdeaInteractionTypes.FirstOrDefault(p => p.IdeaInteractionTypeID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdateIdeaInteractionType(IdeaInteractionType IdeaInteractionType)
        {
            _access.Update(IdeaInteractionType);
        }
    }
}