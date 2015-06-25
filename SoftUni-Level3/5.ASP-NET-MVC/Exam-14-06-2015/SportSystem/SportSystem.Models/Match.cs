namespace SportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Match
    {
        private ICollection<Comment> comments;

        public Match()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        } 
    }
}