using Microsoft.EntityFrameworkCore;
using static TMS_Assesment.Models.CustomClasses;

namespace TMS_Assesment.Models
{
    public class TmsDbContext : DbContext
    {
        public TmsDbContext(DbContextOptions<TmsDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Maintenance> MaintenanceActivities { get; set; }

        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            return await Vehicles.ToListAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Maintenance>()
                .HasOne(m => m.Vehicle)
                .WithMany(v => v.Maintenances)
                .HasForeignKey(m => m.Vehicle_Id);
        }
    }
}
