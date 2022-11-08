namespace RepairNowAPI.Resources;

public class ApplianceResource
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string brand { get; set; }
    public string model { get; set; }
    public int year { get; set; }
    public string urlImage { get; set; }
    public string insuranceDate { get; set; }
    public int clientId { get; set; }
}