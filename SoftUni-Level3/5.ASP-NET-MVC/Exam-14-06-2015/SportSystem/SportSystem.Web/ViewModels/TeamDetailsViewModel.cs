namespace SportSystem.Web.ViewModels
{
    using System;
    using System.Collections.Generic;

    using SportSystem.Common.Mappings;
    using SportSystem.Models;

    public class TeamDetailsViewModel : IMapFrom<Team>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public DateTime DateFounded { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; } 
    }
}