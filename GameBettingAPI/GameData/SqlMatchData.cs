using GameBettingAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameBettingAPI.GameData
{
    public class SqlMatchData : IMatchData
    {
        private MySqlDatabaseContext _mySqlDBContext;
        public SqlMatchData(MySqlDatabaseContext mySqlDBContext)
        {
            _mySqlDBContext = mySqlDBContext;
        }

        public List<Match> GetMatches()
        {
            return _mySqlDBContext.Matches.ToList();
        }

        public Match GetMatch(int matchID)
        {
            return _mySqlDBContext.Matches.FirstOrDefault(a => a.ID == matchID);
        }

        public void AddMatch(Match match)
        {
            match.ID = 0;   // so that this will be auto-incremented by the database
            _mySqlDBContext.Matches.Add(match);
            _mySqlDBContext.SaveChanges();
        }

        public void UpdateMatch(Match old_match, Match new_match)
        {
            old_match.Description = new_match.Description;
            old_match.MatchDate = new_match.MatchDate;
            old_match.MatchTime = new_match.MatchTime;
            old_match.TeamA = new_match.TeamA;
            old_match.TeamB = new_match.TeamB;
            old_match.Sport = new_match.Sport;
            _mySqlDBContext.SaveChanges();
        }

        public void DeleteMatch(int matchID)
        {
            var match = GetMatch(matchID);
            if (match == null) return;
            _mySqlDBContext.Matches.Remove(match);
            _mySqlDBContext.MatchOdds.RemoveRange(_mySqlDBContext.MatchOdds.Where(a => a.MatchID == matchID));
            _mySqlDBContext.SaveChanges();
        }
    }
}
