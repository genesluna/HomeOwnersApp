using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeOwnersApp.Models;

public class HomeOwners
{
    public Guid Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(200)")]
    public string? Name { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(30)")]
    public string? PhoneNumber { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(200)")]
    public string? Site { get; set; }
}
