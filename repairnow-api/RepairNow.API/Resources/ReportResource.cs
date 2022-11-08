namespace RepairNowAPI.Resources;

public class ReportResource
{
    public string observation { get; set; }
    public string diagnosis { get; set; }
    public string repairDescription { get; set; }
    public string date { get; set; }
    public int technicianId { get; set; }
}