namespace GameBettingAPI.Models
{
    public class MatchOdds
    {
        public int ID { get; set; }
        public int MatchID { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Specifier { get; set; }
        public float Odd { get; set; }
    }
}
