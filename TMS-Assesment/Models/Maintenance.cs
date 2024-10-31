using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TMS_Assesment.Models.CustomClasses;

namespace TMS_Assesment.Models
{
    public class Maintenance
    {
        [Key]
        public int? Maintenance_Id { get; set; }
        [ForeignKey("Vehicle")]
        public int? Vehicle_Id { get; set; }
        public string? Maintenance_Type { get; set; }
        public DateTime Maintenance_Date { get; set; }
        public string? Maintenance_Description { get; set; }
        public string? Notes { get; set; }
        public bool? IsActive { get; set; }
        public string? AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public Vehicle? Vehicle { get; set; }

    }
}
