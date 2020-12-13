using System;
using System.Linq;
using Qdea.API.Domain;
using System.Collections.Generic;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IUserIdeas
    {
        bool SaveChanges();

        IEnumerable<UserIdea> GetAllUserIdeas();
        UserIdea GetUserIdeaById(int id);
        void CreateUserIdea(UserIdea userIdea);
        void UpdateUserIdea(UserIdea userIdea);
        void DeleteUserIdea(UserIdea userIdea);
    }

    public class UserIdeasAccess : IUserIdeas
    {
        private readonly DatabaseContext _access;

        public UserIdeasAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateUserIdea(UserIdea cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.UserIdeas.Add(cmd);
        }

        public void DeleteUserIdea(UserIdea userIdea)
        {
            _access.Remove(userIdea);
        }

        public IEnumerable<UserIdea> GetAllUserIdeas()
        {
            return _access.UserIdeas.ToList();
        }

        public UserIdea GetUserIdeaById(int id)
        {
            return _access.UserIdeas.FirstOrDefault(p => p.UserIdeaID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdateUserIdea(UserIdea userIdea)
        {
            _access.Update(userIdea);
        }
    }
}