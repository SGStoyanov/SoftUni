namespace SportSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using PagedList;

    using SportSystem.Common;
    using SportSystem.Data;
    using SportSystem.Web.ViewModels;

    [Authorize]
    public class MatchesController : BaseController
    {
        public MatchesController(ISportSystemData data)
            : base(data)
        {
        }

        // GET: Matches
        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var matches = this.Data
                .Matches
                .All()
                .OrderBy(x => x.MatchDate)
                .Project()
                .To<MatchViewModel>()
                .ToPagedList(page ?? GlobalConstants.DefaultStartPage, GlobalConstants.DefaultPageSize);

            return this.View(matches);
        }
    }
}