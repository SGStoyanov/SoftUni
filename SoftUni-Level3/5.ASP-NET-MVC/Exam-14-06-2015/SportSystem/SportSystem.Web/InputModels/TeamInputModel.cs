namespace SportSystem.Web.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using SportSystem.Common.Mappings;
    using SportSystem.Models;

    [Authorize]
    public class TeamInputModel : IMapTo<Team>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} could not be longer than {2} or empty")]
        public string Name { get; set; }

        public string NickName { get; set; }

        public string WebSite { get; set; }

        public DateTime DateFounded { get; set; }
    }
}