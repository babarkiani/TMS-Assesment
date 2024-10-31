namespace TMS_Assesment.Models
{
    public class CustomClasses
    {
        //public class Vehicle
        //{
        //    public int? Vehicle_Id { get; set; }
        //    public string? Vehicle_Name { get; set; } = "";
        //    public string? Vehicle_Number { get; set; } = "";
        //    //public int Vehicle_Type { get; set; } = ""; // in future we can me a class vehicle type
        //    //public string? Make { get; set; } = ""; // future updates
        //    //public string? Model { get; set; } = ""; // future updates
        //    //public string? Color { get; set; } = ""; // future updates
        //    //public int? Year { get; set; }
        //    public bool? IsActive { get; set; }
        //    public string? AddedBy { get; set; }
        //    public DateTime AddedOn { get; set; }
        //    public string? ModifiedBy { get; set; }
        //    public DateTime ModifiedOn { get; set; }
        //    //public List<MaintenanceActivity>? MaintenanceActivities { get; set; } // future updates
        //}

        //public class MaintenanceActivity
        //{
        //    public int? Maintenance_Id { get; set; }
        //    public int? Vehicle_Id { get; set; } // foreign
        //    public string? Maintenance_Type { get; set; }
        //    public string? Maintenance_Date { get; set; }
        //    public string? Maintenance_Description { get; set; }
        //    public string? Notes { get; set; }
        //    public bool? IsActive { get; set; }
        //    public string? AddedBy { get; set; }
        //    public DateTime AddedOn { get; set; }
        //    public string? ModifiedBy { get; set; }
        //    public DateTime ModifiedOn { get; set; }

        //}

        public class MaintenanceType
        {
            public int Maintenance_Type_Id { get; set; }
            public string? Maintenance_Type { get; set; }
        }
    }
}
