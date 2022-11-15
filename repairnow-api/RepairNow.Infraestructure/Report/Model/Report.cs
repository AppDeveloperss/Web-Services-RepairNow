namespace RepairNow.Infraestructure;

public class Report: BaseModel
{
    public int id { get; set; }
    public string observation { get; set; }
    public string diagnosis { get; set; }
    public string repairDescription { get; set; }
    public string date { get; set; }
    public int technicianId { get; set; }

}