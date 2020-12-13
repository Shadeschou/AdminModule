using System;
using System.Linq;
using Qdea.API.Domain;
using System.Collections.Generic;
using Qdea.API.Models;

namespace Qdea.API.Data
{
    public interface IResults
    {
        bool SaveChanges();

        IEnumerable<Result> GetAllResults();
        Result GetResultById(int id);
        void CreateResult(Result result);
        void UpdateResult(Result result);
        void DeleteResult(Result result);
    }

    public class ResultsAccess : IResults
    {
        private readonly DatabaseContext _access;

        public ResultsAccess(DatabaseContext dbAccess)
        {
            _access = dbAccess;
        }

        public void CreateResult(Result cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _access.Results.Add(cmd);
        }

        public void DeleteResult(Result result)
        {
            _access.Remove(result);
        }

        public IEnumerable<Result> GetAllResults()
        {
            return _access.Results.ToList();
        }

        public Result GetResultById(int id)
        {
            return _access.Results.FirstOrDefault(p => p.ResultID == id);
        }

        public bool SaveChanges()
        {
            return (_access.SaveChanges() >= 0);
        }

        public void UpdateResult(Result result)
        {
            _access.Update(result);
        }
    }
}