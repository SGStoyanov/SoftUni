﻿namespace SportSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Bet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Money { get; set; }

        [Required]
        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        public decimal? HomeTeamBet { get; set; }

        public virtual Team HomeTeam { get; set; }

        public decimal? AwayTeamBet { get; set; }

        public virtual Team AwayTeam { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}