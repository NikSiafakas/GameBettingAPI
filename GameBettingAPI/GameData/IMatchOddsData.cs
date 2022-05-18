using GameBettingAPI.Models;
using System.Collections.Generic;

namespace GameBettingAPI.GameData
{
    public interface IMatchOddsData
    {
        List<MatchOdds> GetMatchOdds_All();

        List<MatchOdds> GetMatchOdds_SingleMatch(int matchID);

        MatchOdds GetMatchOdds(int oddsID);

        void AddMatchOdds(MatchOdds odds);

        void UpdateMatchOdds(MatchOdds old_odds, MatchOdds new_odds);

        void DeleteMatchOdds(int oddsID);
    }
}
