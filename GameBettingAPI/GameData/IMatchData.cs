using GameBettingAPI.Models;
using System.Collections.Generic;

namespace GameBettingAPI.GameData
{
    public interface IMatchData
    {
        List<Match> GetMatches();

        Match GetMatch(int matchID);

        void AddMatch(Match match);

        void UpdateMatch(Match old_match, Match new_match);

        void DeleteMatch(int matchID);
    }
}
