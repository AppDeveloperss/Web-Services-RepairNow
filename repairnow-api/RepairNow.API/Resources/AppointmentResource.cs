using System.ComponentModel.DataAnnotations;

namespace RepairNowAPI.Resources;

public class AppointmentResource
{
    [Required]
    public string dateReserve { get; set; }
    [Required]
    public string dateAttention { get; set; }
    [Required]
    public string hour { get; set; }
    [Required]
    public int clientId { get; set; }
    [Required]
    public int applianceModelId { get; set; }
}