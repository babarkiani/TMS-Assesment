using Microsoft.AspNetCore.Identity;

namespace TMS_Assesment.Models
{
    public class TmsUser: IdentityUser
    { 
        public string? User_Name { get; set; }
    }
}
