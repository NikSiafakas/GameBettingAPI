using GameBettingAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameBettingAPI.GameData
{
    public class SqlMatchOddsData : IMatchOddsData
    {
        private MySqlDatabaseContext _mySqlDBContext;
        public SqlMatchOddsData(MySqlDatabaseContext mySqlDBContext)
        {
            _mySqlDBContext = mySqlDBContext;
        }

        public List<MatchOdds> GetMatchOdds_All()
        {
            return _mySqlDBContext.MatchOdds.ToList();
        }

        public List<MatchOdds> GetMatchOdds_SingleMatch(int matchID)
        {
            return _mySqlDBContext.MatchOdds.Where(a => a.MatchID == matchID).ToList();
        }

        public MatchOdds GetMatchOdds(int oddsID)
        {
            return _mySqlDBContext.MatchOdds.FirstOrDefault(a => a.ID == oddsID);
        }

        public void AddMatchOdds(MatchOdds odds)
        {
            odds.ID = 0;    // so that this will be auto-incremented by the database
            _mySqlDBContext.MatchOdds.Add(odds);
            _mySqlDBContext.SaveChanges();
        }

        public void UpdateMatchOdds(MatchOdds old_odds, MatchOdds new_odds)
        {
            old_odds.MatchID = new_odds.MatchID;
            old_odds.Specifier = new_odds.Specifier;
            old_odds.Odd = new_odds.Odd;
            _mySqlDBContext.SaveChanges();
        }

        public void DeleteMatchOdds(int oddsID)
        {
            var matchOdds = GetMatchOdds(oddsID);
            if (matchOdds == null) return;
            _mySqlDBContext.MatchOdds.Remove(matchOdds);
            _mySqlDBContext.SaveChanges();
        }
    }
}
