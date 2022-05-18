using System;
using System.ComponentModel.DataAnnotations;

namespace GameBettingAPI.Models
{
    public class Match
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
        private DateTime MatchDateTime { get; set; }
        [Required]
        public string MatchDate {
            get => MatchDateTime.ToString("dd/MM/yyyy");
            set {
                if (DateTime.TryParse(value, out DateTime date))
                    MatchDateTime = new DateTime(date.Year, date.Month, date.Day, MatchDateTime.Hour, MatchDateTime.Minute, MatchDateTime.Second);
            }
        }
        [Required]
        public string MatchTime
        {
            get => MatchDateTime.ToString("HH:mm");
            set
            {
                if (DateTime.TryParse(value, out DateTime time))
                    MatchDateTime = new DateTime(MatchDateTime.Year, MatchDateTime.Month, MatchDateTime.Day, time.Hour, time.Minute, time.Second);
            }
        }
        [Required]
        public string TeamA { get; set; }
        [Required]
        public string TeamB { get; set; }
        public Sports Sport { get; set; }
    }

    public enum Sports { Football = 1, Basketball }
}
