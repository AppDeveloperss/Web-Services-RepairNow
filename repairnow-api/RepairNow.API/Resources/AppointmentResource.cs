namespace RepairNowAPI.Resources;

public class AppointmentResource
{
    public int id { get; set; }
    public string dateReserve { get; set; }
    public string dateAttention { get; set; }
    public string hour { get; set; }
    public int clientId { get; set; }
    public int applianceModelId { get; set; }
}