using Microsoft.AspNetCore.Mvc;
using static TMS_Assesment.Models.CustomClasses;
using TMS_Assesment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TMS_Assesment.Controllers
{
    [Route("Maintenance")]
    public class MaintenanceController : Controller
    {
        private readonly TmsDbContext _context;

        public MaintenanceController(TmsDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var vehicles = await _context.GetVehiclesAsync();

            var maintenanceTypes = new List<MaintenanceType>
            {
                new MaintenanceType { Maintenance_Type_Id = 1, Maintenance_Type = "Oil Change" },
                new MaintenanceType { Maintenance_Type_Id = 2, Maintenance_Type = "Tire Rotation" },
                new MaintenanceType { Maintenance_Type_Id = 3, Maintenance_Type = "Brake Inspection" },
                new MaintenanceType { Maintenance_Type_Id = 4, Maintenance_Type = "Engine Tune-Up" }
            };

            ViewBag.MaintenanceTypes = maintenanceTypes;
            ViewBag.Vehicles = vehicles;

            return View();
        }

        #region TMS setup

        [HttpGet("GetMaintenanceActivities")]
        public async Task<IActionResult> GetMaintenanceActivities()
        {
            var maintenanceRecords = await _context.MaintenanceActivities
                .Where(m => m.IsActive == true)
                .Include(m => m.Vehicle)
                .Select(m => new {
                    m.Maintenance_Id,
                    m.Vehicle_Id,
                    VehicleName = m.Vehicle!.Vehicle_Name,
                    m.Maintenance_Type,
                    m.Maintenance_Date,
                    m.Maintenance_Description,
                    m.Notes
                })
                .ToListAsync();

            return Json(new { data = maintenanceRecords });
        }

        [HttpGet("GetMaintenanceActivity/{id}")]
        public async Task<IActionResult> GetMaintenanceActivity(int id)
        {
            try
            {
                var activity = await _context.MaintenanceActivities
                .Where(m => m.Maintenance_Id == id)
                .Select(m => new {
                    m.Maintenance_Id,
                    m.Vehicle_Id,
                    m.Maintenance_Type,
                    m.Maintenance_Date,
                    m.Maintenance_Description,
                    m.Notes
                })
                .FirstOrDefaultAsync();

                if (activity == null)
                {
                    return NotFound();
                }

                return Json(activity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error. Please check the logs.");
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("AddOrEditMaintenanceActivity")]
        public async Task<IActionResult> AddOrEditMaintenanceActivity(Maintenance activity)
        {
            try
            {
                activity.AddedBy = "Admin";
                activity.AddedOn = DateTime.UtcNow;
                activity.IsActive = true;

                if (activity.Maintenance_Id > 0)
                {
                    var existingActivity = await _context.MaintenanceActivities.FindAsync(activity.Maintenance_Id);
                    if (existingActivity == null)
                    {
                        return Json(new { success = false, message = "Maintenance activity not found." });
                    }

                    existingActivity.Vehicle_Id = activity.Vehicle_Id;
                    existingActivity.Maintenance_Type = activity.Maintenance_Type;
                    existingActivity.Maintenance_Date = activity.Maintenance_Date;
                    existingActivity.Maintenance_Description = activity.Maintenance_Description;
                    existingActivity.Notes = activity.Notes;

                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Maintenance activity updated successfully." });
                }
                else
                {
                    await _context.MaintenanceActivities.AddAsync(activity);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Maintenance activity added successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> UpdateMaintenanceActivity(Maintenance activity)
        {
            try
            {
                var existingActivity = await _context.MaintenanceActivities.FindAsync(activity.Maintenance_Id);

                if (existingActivity != null)
                {
                    existingActivity.Vehicle_Id = activity.Vehicle_Id;
                    existingActivity.Maintenance_Type = activity.Maintenance_Type;
                    existingActivity.Maintenance_Date = activity.Maintenance_Date;
                    existingActivity.Maintenance_Description = activity.Maintenance_Description;
                    existingActivity.Notes = activity.Notes;
                    existingActivity.ModifiedBy = "ADMIN";  //User.Identity.Name;
                    existingActivity.ModifiedOn = DateTime.UtcNow;

                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Maintenance activity updated successfully." });
                }

                return Json(new { success = false, message = "Maintenance activity not found." });
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message});

            }
        }



        [HttpPost]
        public async Task<IActionResult> DeleteMaintenanceActivity(int id)
        {
            var maintenance = await _context.MaintenanceActivities.FindAsync(id);
            if (maintenance == null)
            {
                return NotFound();
            }
            maintenance.IsActive = false;
            _context.MaintenanceActivities.Update(maintenance);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Maintenance record marked as inactive." });
        }
        #endregion TMS setup
    }

}
