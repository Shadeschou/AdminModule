using System;
using System.Collections.Generic;
using System.Linq;
using Qdea.API.Domain;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IAddedUser
    {
        bool SaveChanges();

        IEnumerable<AddedUser> GetAllAddedUsers();
        AddedUser GetAddedUserById(int id);
        void CreateAddedUser(AddedUser AddedUser);
        void UpdateAddedUser(AddedUser AddedUser);
        void DeleteAddedUser(AddedUser AddedUser);
    }

    public class AddedUsersAccess : IAddedUser
    {
        private readonly DatabaseContext _access;

        public AddedUsersAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateAddedUser(AddedUser cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));

            _access.AddedUsers.Add(cmd);
        }

        public void DeleteAddedUser(AddedUser AddedUser)
        {
            _access.Remove(AddedUser);
        }

        public IEnumerable<AddedUser> GetAllAddedUsers()
        {
            return _access.AddedUsers.ToList();
        }

        public AddedUser GetAddedUserById(int id)
        {
            return _access.AddedUsers.FirstOrDefault(p => p.AddedUserID == id);
        }

        public bool SaveChanges()
        {
            return _access.SaveChanges() >= 0;
        }

        public void UpdateAddedUser(AddedUser AddedUser)
        {
            _access.Update(AddedUser);
        }
    }
}