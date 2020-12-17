using System;
using System.Collections.Generic;
using System.Linq;
using Qdea.API.Domain;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IUser
    {
        bool SaveChanges();

        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }

    public class UsersAccess : IUser
    {
        private readonly DatabaseContext _access;

        public UsersAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateUser(User cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));

            _access.Users.Add(cmd);
        }

        public void DeleteUser(User user)
        {
            _access.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _access.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _access.Users.FirstOrDefault(p => p.UserID == id);
        }

        public bool SaveChanges()
        {
            return _access.SaveChanges() >= 0;
        }

        public void UpdateUser(User user)
        {
            _access.Update(user);
        }
    }
}