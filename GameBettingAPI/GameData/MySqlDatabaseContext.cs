using GameBettingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameBettingAPI.GameData
{
    public class MySqlDatabaseContext : DbContext
    {
        public MySqlDatabaseContext(DbContextOptions<MySqlDatabaseContext> options) : base(options) { }

        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchOdds> MatchOdds { get; set; }
    }
}
