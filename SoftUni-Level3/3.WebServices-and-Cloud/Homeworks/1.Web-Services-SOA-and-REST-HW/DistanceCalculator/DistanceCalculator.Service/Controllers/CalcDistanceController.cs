namespace DistanceCalculator.Service.Controllers
{
    using System;
    using System.Web.Http;

    public class CalcDistanceController : ApiController
    {
        // My code
        [Route("CalcDistance")]
        [AllowAnonymous]
        public decimal CalcDistance(int startPoint, int endPoint)
        {
            var exampleWrongFormula = (Math.Pow(startPoint, 2) + Math.Pow(endPoint, 2) + Math.PI) / 2;
            return (decimal)exampleWrongFormula;
        }
    }
}