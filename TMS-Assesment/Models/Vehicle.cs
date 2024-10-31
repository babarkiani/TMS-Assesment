using System.ComponentModel.DataAnnotations;

namespace TMS_Assesment.Models
{
    public class Vehicle
    {
        [Key]
        public int? Vehicle_Id { get; set; }
        public string? Vehicle_Name { get; set; }
        public string? Vehicle_Number { get; set; }
        public bool? IsActive { get; set; }
        public string? AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public ICollection<Maintenance>? Maintenances { get; set; }
    }
}
