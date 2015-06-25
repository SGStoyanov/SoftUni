namespace SportSystem.Web.ViewModels
{
    using System;

    using SportSystem.Common.Mappings;
    using SportSystem.Models;

    public class PlayerViewModel : IMapFrom<Player>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public float Height { get; set; }
    }
}