using System;
using System.Linq;
using Qdea.API.Domain;
using System.Collections.Generic;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IComments
    {
        bool SaveChanges();

        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById(int id);
        void CreateComment(Comment Comment);
        void UpdateComment(Comment comment);
        void DeleteComment(Comment comment);
    }

    public class CommentsAccess : IComments
    {
        private readonly DatabaseContext _access;

        public CommentsAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateComment(Comment cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.Comments.Add(cmd);
        }

        public void DeleteComment(Comment comment)
        {
            _access.Remove(comment);
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _access.Comments.ToList();
        }

        public Comment GetCommentById(int id)
        {
            return _access.Comments.FirstOrDefault(p => p.CommentID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdateComment(Comment comment)
        {
            _access.Update(comment);
        }
    }
}