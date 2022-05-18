using GameBettingAPI.GameData;
using GameBettingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GameBettingAPI.Controllers
{
    [ApiController]
    public class GameBetController : ControllerBase
    {
        private IMatchData _matchData;
        private IMatchOddsData _matchOddsData;
        public GameBetController(IMatchData matchData, IMatchOddsData matchOddsData)
        {
            _matchData = matchData;
            _matchOddsData = matchOddsData;
        }

        #region Match
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetMatches()
        {
            var matches = _matchData.GetMatches();
            if (matches.Any()) return Ok(matches);
            return NotFound("No matches found.");
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetMatch(int id)
        {
            var match = _matchData.GetMatch(id);
            if (match != null) return Ok(match);
            return NotFound($"Match: {id} was not found.");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddMatch(Match match)
        {
            if (match == null) return BadRequest("Operation Failed.");

            _matchData.AddMatch(match);
            return Ok(_matchData.GetMatches());
        }

        [HttpPut]
        [Route("api/[controller]")]
        public IActionResult UpdateMatch(Match match)
        {
            if (match == null) return BadRequest("Operation Failed.");

            var existingMatch = _matchData.GetMatch(match.ID);
            if (existingMatch == null) return NotFound("Match not found.");

            _matchData.UpdateMatch(existingMatch, match);
            return Ok(_matchData.GetMatches());
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteMatch(int id)
        {
            _matchData.DeleteMatch(id);
            return GetMatches();
        }
        #endregion

        #region MatchOdds
        [HttpGet]
        [Route("api/[controller]/odds")]
        public IActionResult GetMatchOdds_All()
        {
            var match_odds = _matchOddsData.GetMatchOdds_All();
            if (match_odds.Any()) return Ok(match_odds);
            return NotFound("No match odds found.");
        }

        [HttpGet]
        [Route("api/[controller]/odds/match/{matchID}")]
        public IActionResult GetMatchOdds_SingleMatch(int matchID)
        {
            var match_odds = _matchOddsData.GetMatchOdds_SingleMatch(matchID);
            if (match_odds.Any()) return Ok(match_odds);
            return NotFound("No match odds found.");
        }

        [HttpGet]
        [Route("api/[controller]/odds/{oddsID}")]
        public IActionResult GetMatchOdds(int oddsID)
        {
            var match_odds = _matchOddsData.GetMatchOdds(oddsID);
            if (match_odds != null) return Ok(match_odds);
            return NotFound($"Match odds: {oddsID} were not found.");
        }

        [HttpPost]
        [Route("api/[controller]/odds")]
        public IActionResult AddMatchOdds(MatchOdds odds)
        {
            if (odds == null) return BadRequest("Operation Failed.");

            _matchOddsData.AddMatchOdds(odds);
            return Ok(_matchOddsData.GetMatchOdds_All());
        }

        [HttpPut]
        [Route("api/[controller]/odds")]
        public IActionResult UpdateMatchOdds(MatchOdds odds)
        {
            if (odds == null) return BadRequest("Operation Failed.");

            var existingMatchOdds = _matchOddsData.GetMatchOdds(odds.ID);
            if (existingMatchOdds == null) return NotFound("Match odds not found.");

            _matchOddsData.UpdateMatchOdds(existingMatchOdds, odds);
            return Ok(_matchOddsData.GetMatchOdds_All());
        }

        [HttpDelete]
        [Route("api/[controller]/odds/{oddsID}")]
        public IActionResult DeleteMatchOdds(int oddsID)
        {
            _matchOddsData.DeleteMatchOdds(oddsID);
            return GetMatchOdds_All();
        }
        #endregion
    }
}
