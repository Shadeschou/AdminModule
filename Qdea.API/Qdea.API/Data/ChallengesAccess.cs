using System;
using System.Linq;
using Qdea.API.Domain;
using System.Collections.Generic;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IChallenges
    {
        bool SaveChanges();

        IEnumerable<Challenge> GetAllChallenges();
        Challenge GetChallengeById(int id);
        void CreateChallenge(Challenge challenge);
        void UpdateChallenge(Challenge challenge);
        void DeleteChallenge(Challenge challenge);
    }

    public class ChallengesAccess : IChallenges
    {
        private readonly DatabaseContext _access;

        public ChallengesAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateChallenge(Challenge cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.Challenges.Add(cmd);
        }

        public void DeleteChallenge(Challenge challenge)
        {
            _access.Remove(challenge);
        }

        public IEnumerable<Challenge> GetAllChallenges()
        {
            return _access.Challenges.ToList();
        }

        public Challenge GetChallengeById(int id)
        {
            return _access.Challenges.FirstOrDefault(p => p.ChallengeID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdateChallenge(Challenge challenge)
        {
            _access.Update(challenge);
        }
    }
}