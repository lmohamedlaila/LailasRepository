

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Repositories
{
    public class MatchRepository : Repository , IMatchRepository
    {
        private readonly SportMatchesEntities _sport_MatchesEntities; 
        public MatchRepository(SportMatchesEntities dbContext) : base(dbContext)
        {
            _sport_MatchesEntities = dbContext;
        }
        public IQueryable<Match> GetAll()
        {
            try
            {
                return _sport_MatchesEntities.Matches;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
