namespace SportSystem.Web.ViewModels
{
    using System;

    using SportSystem.Common.Mappings;
    using SportSystem.Models;

    public class TeamViewModel : IMapFrom<Team>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string WebSite { get; set; }

        public string NickName { get; set; }

        public DateTime DateFounded { get; set; }
    }
}