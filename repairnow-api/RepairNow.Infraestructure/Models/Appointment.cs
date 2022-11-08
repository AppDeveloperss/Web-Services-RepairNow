namespace RepairNow.Infraestructure;

public class Appointment: BaseModel
{
    public int id { get; set; }
    public string dateReserve { get; set; }
    public string dateAttention { get; set; }
    public string hour { get; set; }
    public int clientId { get; set; }
    public User User { get; set; }
    public int applianceModelId { get; set; }
    public Appliance Appliance { get; set; }
    
}