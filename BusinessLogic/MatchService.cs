

using DataAccess;
using DataAccess.Repositories;
using Model;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class MatchService : IMatchService
    {
        IMatchRepository _matchRepository;
        SportMatchesEntities _sport_MatchesEntities;
        public MatchService()
        {
            _sport_MatchesEntities = new SportMatchesEntities();
            _matchRepository = new MatchRepository(_sport_MatchesEntities);
        }

        public List<MatchModel> GetAll()
        {
            try
            {
                TimeSpan ts;
                var list = new List<MatchModel>();
                var result = _matchRepository.GetAll();
                foreach (var item in result)
                {
                    var match = new MatchModel();
                    match.Location = item.Location;
                    match.MatchDate = Convert.ToDateTime(item.MatchDate);
                    if (item.MatchEndTime != null && item.MatchEndTime > 0)
                    {
                         ts = ConvertIntToTimeSpan(Convert.ToInt32(item.MatchEndTime));
                        match.MatchEndTime = ts.ToString();
                    }
                    if (item.MatchStartTime != null && item.MatchStartTime > 0)
                    {
                        ts = ConvertIntToTimeSpan(Convert.ToInt32(item.MatchStartTime));
                        match.MatchStartTime = ts.ToString();
                    }
                    if (item.OpeningGatesTime != null && item.OpeningGatesTime > 0)
                    {
                        ts = ConvertIntToTimeSpan(Convert.ToInt32(item.OpeningGatesTime));
                        match.OpeningGatesTime = ts.ToString();
                    }
                    match.TeamOne = item.TeamOne;
                    match.TeamTwo = item.TeamTwo;
                    match.StadiumName = item.StadiumName;
                    match.MatchID = item.MatchID;
                    
                    list.Add(match);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static TimeSpan ConvertIntToTimeSpan(int Minutes)
        {
            return TimeSpan.FromMinutes(Convert.ToInt32(Minutes));
        }
    }
}
