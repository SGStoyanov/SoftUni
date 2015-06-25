namespace SportSystem.Web.ViewModels
{
    using System;

    using AutoMapper;

    using SportSystem.Common.Mappings;
    using SportSystem.Models;

    public class MatchViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public DateTime MatchDate { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Match, MatchViewModel>()
                .ForMember(x => x.HomeTeam, cnf => cnf.MapFrom(h => h.HomeTeam.Name))
                .ForMember(x => x.AwayTeam, cnf => cnf.MapFrom(a => a.AwayTeam.Name));
        }
    }
}