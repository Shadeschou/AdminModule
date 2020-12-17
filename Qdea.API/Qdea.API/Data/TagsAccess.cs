using System;
using System.Collections.Generic;
using System.Linq;
using Qdea.API.Domain;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface ITag
    {
        bool SaveChanges();

        IEnumerable<Tag> GetAllTags();
        Tag GetTagById(int id);
        void CreateTag(Tag tag);
        void UpdateTag(Tag tag);
        void DeleteTag(Tag tag);
    }

    public class TagsAccess : ITag
    {
        private readonly DatabaseContext _access;

        public TagsAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateTag(Tag cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));

            _access.Tags.Add(cmd);
        }

        public void DeleteTag(Tag tag)
        {
            _access.Remove(tag);
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _access.Tags.ToList();
        }

        public Tag GetTagById(int id)
        {
            return _access.Tags.FirstOrDefault(p => p.TagID == id);
        }

        public bool SaveChanges()
        {
            return _access.SaveChanges() >= 0;
        }

        public void UpdateTag(Tag tag)
        {
            _access.Update(tag);
        }
    }
}