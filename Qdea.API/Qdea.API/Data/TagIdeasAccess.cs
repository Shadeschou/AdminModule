using System;
using System.Linq;
using Qdea.API.Domain;
using System.Collections.Generic;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface ITagIdeas
    {
        bool SaveChanges();

        IEnumerable<TagIdea> GetAllTagIdeas();
        TagIdea GetTagIdeaById(int id);
        void CreateTagIdea(TagIdea tagIdea);
        void UpdateTagIdea(TagIdea tagIdea);
        void DeleteTagIdea(TagIdea tagIdea);
    }

    public class TagIdeasAccess : ITagIdeas
    {
        private readonly DatabaseContext _access;

        public TagIdeasAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateTagIdea(TagIdea cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.TagIdeas.Add(cmd);
        }

        public void DeleteTagIdea(TagIdea tagIdea)
        {
            _access.Remove(tagIdea);
        }

        public IEnumerable<TagIdea> GetAllTagIdeas()
        {
            return _access.TagIdeas.ToList();
        }

        public TagIdea GetTagIdeaById(int id)
        {
            return _access.TagIdeas.FirstOrDefault(p => p.TagListID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdateTagIdea(TagIdea tagIdea)
        {
            _access.Update(tagIdea);
        }
    }
}