using System.ComponentModel.DataAnnotations;

namespace HomeOwnersApp.Models;

public class HomeOwners
{
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? PhoneNumber { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public string? Site { get; set; }
}
