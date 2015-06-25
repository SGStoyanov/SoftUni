namespace SportSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using PagedList;

    using SportSystem.Common;
    using SportSystem.Data;
    using SportSystem.Models;
    using SportSystem.Web.InputModels;
    using SportSystem.Web.ViewModels;

    [Authorize]
    public class TeamsController : BaseController
    {
        public TeamsController(ISportSystemData data)
            : base(data)
        {
        }

        public ActionResult Index(int? page)
        {
            var teams = this.Data
                .Teams
                .All()
                .OrderBy(x => x.Name)
                .Project()
                .To<TeamDetailsViewModel>()
                .ToPagedList(page ?? GlobalConstants.DefaultStartPage, GlobalConstants.DefaultPageSize);

            return this.View(teams);
        }

        public ActionResult Details(int id)
        {
            
            var team = this.Data
                .Teams
                .All()
                .Where(x => x.Id == id)
                .Project()
                .To<TeamDetailsViewModel>()
                .FirstOrDefault();

            if (team != null)
            {
                return this.View(team);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var team = Mapper.Map<Team>(model);
                this.Data.Teams.Add(team);
                this.Data.SaveChanges();

                return this.RedirectToAction("Details", new { id = team.Id });
            }

            //this.LoadCategories();
            return this.View(model);
        }

    }
}