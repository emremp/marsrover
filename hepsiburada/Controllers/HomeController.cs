using System.Web.Mvc;
using Business;

namespace hepsiburada.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index ()
		{
			var boundaries = new Plateau {XAxisMin = 0, XAxisMax = 5, YAxisMin = 0, YAxisMax = 5};

		    var rover1 = new Rover ();
			rover1.SetRoverBoundaries (boundaries);
            var location = new Location() { xAxis = 1, yAxis = 2, Direction = CompassDirection.North };
			var onSet = rover1.InitialLocationSet (location);
			if (onSet) {
				var stringRoute = "LMLMLMLMM";
				char[] stringRouteCharArr = stringRoute.ToCharArray ();

				rover1.SetRoute (stringRouteCharArr);
				var result = rover1.Navigate ();
				ViewData ["OutputFirst"] = result;
			} else {
				ViewData ["OutputFirst"] = "not valid location";
			}


			var rover2 = new Rover ();
			rover2.SetRoverBoundaries (boundaries);
            var location2 = new Location() { xAxis = 3, yAxis = 3, Direction = CompassDirection.East };
            var onSet2 = rover2.InitialLocationSet(location2);
			if (onSet2) {
				var stringRoute2 = "MMRMMRMRRM";
				char[] stringRouteCharArr2 = stringRoute2.ToCharArray ();

				rover2.SetRoute (stringRouteCharArr2);
				var result2 = rover2.Navigate ();
				ViewData ["OutputSecond"] = result2;
			} else {
				ViewData ["OutputSecond"] = "not valid location";

			}




			return View ();
		}
	}
}

