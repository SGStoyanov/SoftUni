namespace SportSystem.Web.Controllers
{
    using System.Web.Mvc;

    using SportSystem.Data;

    public abstract class BaseController : Controller
    {
        protected BaseController(ISportSystemData data)
        {
            this.Data = data;
        }

        public ISportSystemData Data { get; private set; }
    }
}