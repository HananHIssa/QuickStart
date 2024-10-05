using Microsoft.AspNetCore.Mvc;

namespace QuickStart.PL.Areas.Dashboard.Controllers
{
	public class CatagoryController : Controller
	{
		[Area("Dashboard")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
