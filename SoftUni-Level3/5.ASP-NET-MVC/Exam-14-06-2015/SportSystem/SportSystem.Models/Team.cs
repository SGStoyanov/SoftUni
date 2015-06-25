namespace SportSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        private ICollection<Player> players;

        private ICollection<Vote> votes;

        public Team()
        {
            this.players = new HashSet<Player>();
            this.votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} could not be longer than {2} or empty")]
        public string Name { get; set; }

        public string NickName { get; set; }

        public string WebSite { get; set; }

        public DateTime DateFounded { get; set; }

        public virtual ICollection<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        } 
    }
}