using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeOwnersApp.Areas.Identity.Data;

public class AppUser : IdentityUser
{
    [PersonalData]
    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string? Name { get; set; }
}