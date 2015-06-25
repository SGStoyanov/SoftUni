namespace TwitterNG.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using TwitterNG.Data;

    public class HomeController : BaseController
    {
        
        public ActionResult Index()
        {
            if (this.UserProfile != null)
            {
                this.ViewBag.Username = this.UserProfile.UserName;
            }

            var tweets = this.Data.Tweets.All().AsEnumerable();
            return this.View(tweets);
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

        public HomeController(ITwitterNgData data)
            : base(data)
        {
        }
    }
}