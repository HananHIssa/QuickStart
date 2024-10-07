using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuickStart.DAL.Data;
using QuickStart.DAL.Data.Models;
using QuickStart.PL.Areas.Dashboard.ViewModels;

namespace QuickStart.PL.Areas.Dashboard.Controllers
{		
    [Area("Dashboard")]
    public class ServicesController : Controller
    {

		private readonly ApplicationDbContext context;
		private readonly IMapper mappper;


		public ServicesController(ApplicationDbContext context,IMapper mappper)
		{
			this.context = context;
            this.mappper = mappper;
		}
        [HttpGet]
		public IActionResult Index()
        {
            var services = context.Services.ToList();
            var mApping= mappper.Map<IEnumerable<vmService>>(services);
			return View(mApping);
        }
        [HttpGet]
        public IActionResult Create ()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServicesFormVm vm)
        {
            if(ModelState.IsValid)
            {
                var services = mappper.Map<Services>(vm);
                context.Services.Add(services);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult Details (int id)
        {
			return View(mappper.Map<ServiceDetailsvm>(context.Services.Find(id)));
		}
        public IActionResult Edit(int id)
        {
            var x = context.Services.Find(id);
			return View(mappper.Map<ServiceDetailsvm>(context.Services.Find(id)));
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ServiceDetailsvm vm)
		{
			if (ModelState.IsValid)
			{
				var x = context.Services.Find(vm.Id); 
				if (x == null)
				{
					return NotFound();
				}
				mappper.Map(vm, x);

				context.Services.Update(x);
				context.SaveChanges(); 

				return RedirectToAction("Index");
			}
			return View(vm);
		}
        public IActionResult Delete(int id)
        {
            var con = context.Services.Find(id);
            context.Services.Remove(con);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}
