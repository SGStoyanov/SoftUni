namespace TwitterNG.Web.Controllers
{
    using System.Web.Mvc;

    using TwitterNG.Web.Controllers;
    using TwitterNG.Data;

    public class HomeController : BaseController
    {
        public HomeController(ITwitterNgData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            if (this.UserProfile != null)
            {
                this.ViewBag.Username = this.UserProfile.UserName;
            }

            return this.View();
        }

        public ActionResult About()
        {
            //return this.RedirectToAction(x => x.Contact());
            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "My contact page.";

            return this.View();
        }
    }
}