using Microsoft.Build.Framework;

namespace RepairNowAPI.Resources;

public class ApplianceResource
{
    [Required]
    public string name { get; set; }
    [Required]
    public string description { get; set; }
    [Required]
    public string brand { get; set; }
    [Required]
    public string model { get; set; }
    [Required]
    public int year { get; set; }
    [Required]
    public string urlImage { get; set; }
    [Required]
    public string insuranceDate { get; set; }
    [Required]
    public int clientId { get; set; }
}