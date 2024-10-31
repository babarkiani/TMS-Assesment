using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TMS_Assesment.Models;
using static TMS_Assesment.Models.CustomClasses;

namespace TMS_Assesment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TmsDbContext _context;
        public HomeController(ILogger<HomeController> logger, TmsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var activities = _context.MaintenanceActivities.Include(m => m.Vehicle_Id).ToList();
            //return View(activities);

        //    var vehicles = new List<Vehicle>
        //{
        //    new Vehicle { Vehicle_Id = 1, Vehicle_Name = "Mazda", Vehicle_Number = "888" },
        //    new Vehicle { Vehicle_Id = 2, Vehicle_Name = "Nissan", Vehicle_Number = "123" },
        //    new Vehicle { Vehicle_Id = 3, Vehicle_Name = "Mercedez", Vehicle_Number = "589" },
        //};

        //    var maintenanceTypes = new List<MaintenanceType>
        //{
        //    new MaintenanceType { Maintenance_Type_Id = 1, Maintenance_Type = "Oil Change" },
        //    new MaintenanceType { Maintenance_Type_Id = 2, Maintenance_Type = "Tire Rotation" },
        //    new MaintenanceType { Maintenance_Type_Id = 3, Maintenance_Type = "Brake Inspection" },
        //    new MaintenanceType { Maintenance_Type_Id = 4, Maintenance_Type = "Engine Tune-Up" }
        //};
        //    ViewBag.MaintenanceTypes = maintenanceTypes;
        //    ViewBag.Vehicles = vehicles;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
