namespace SportSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using SportSystem.Data;
    using SportSystem.Web.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(ISportSystemData data)
            : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var topMatches =
                this.Data.Matches.All()
                    .Take(3)
                    .Project()
                    .To<MatchViewModel>();

            var bestTeams = this.Data
                .Teams
                .All()
                .OrderByDescending(x => x.Votes.Count)
                .Take(3)
                .Project()
                .To<TeamViewModel>();

            var homeModelView = 
                new HomeViewModel()
                {
                    Matches = topMatches,
                    Teams = bestTeams
                };

            return this.View(bestTeams);
        }
    }
}