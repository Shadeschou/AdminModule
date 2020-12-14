using System;
using System.Collections.Generic;
using System.Linq;
using Qdea.API.Domain;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IIdea
    {
        bool SaveChanges();

        IEnumerable<Idea> GetAllIdeas();
        Idea GetIdeaById(int id);
        void CreateIdea(Idea idea);
        void UpdateIdea(Idea idea);
        void DeleteIdea(Idea idea);
    }

    public class IdeasAccess : IIdea
    {
        private readonly DatabaseContext _access;

        public IdeasAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateIdea(Idea cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.Ideas.Add(cmd);
        }

        public void DeleteIdea(Idea idea)
        {
            _access.Remove(idea);
        }

        public IEnumerable<Idea> GetAllIdeas()
        {
            return _access.Ideas.ToList();
        }

        public Idea GetIdeaById(int id)
        {
            return _access.Ideas.FirstOrDefault(p => p.IdeaID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdateIdea(Idea idea)
        {
             _access.Update(idea);
        }
    }
}