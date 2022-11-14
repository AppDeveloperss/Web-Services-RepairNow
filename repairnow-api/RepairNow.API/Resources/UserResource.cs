using System.ComponentModel.DataAnnotations;

namespace RepairNowAPI.Resources;

public class UserResource
{
    [Required]
    public string firstName { get; set; }
    [Required]
    public string lastName { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string password { get; set; }
    [Required]
    public string address { get; set; }
    [Required]
    public string phone { get; set; }
    [Required]
    public string type { get; set; }
    [Required]
    public string? plan { get; set; }
}