using Microsoft.Build.Framework;

namespace RepairNow.Infraestructure;

public class Login
{
    [Required]
    public string email { get; set; }
    [Required]
    public string password { get; set; }
}