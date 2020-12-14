using System;
using System.Linq;
using System.Collections.Generic;
using Qdea.API.Domain;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IUserStatus
    {
        bool SaveChanges();

        IEnumerable<UserStatus> GetAllUserStatuses();
        UserStatus GetUserStatusById(int id);
        void CreateUserStatus(UserStatus userStatus);
        void UpdateUserStatus(UserStatus userStatus);
        void DeleteUserStatus(UserStatus userStatus);
    }

    public class UserStatusesAccess : IUserStatus
    {
        private readonly DatabaseContext _access;

        public UserStatusesAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateUserStatus(UserStatus cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.UserStatuses.Add(cmd);
        }

        public void DeleteUserStatus(UserStatus userStatus)
        {
            _access.Remove(userStatus);
        }

        public IEnumerable<UserStatus> GetAllUserStatuses()
        {
            return _access.UserStatuses.ToList();
        }

        public UserStatus GetUserStatusById(int id)
        {
            return _access.UserStatuses.FirstOrDefault(p => p.UserStatusID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdateUserStatus(UserStatus userStatus)
        {
            _access.Update(userStatus);
        }
    }
}