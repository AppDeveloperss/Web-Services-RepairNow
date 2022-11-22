namespace RepairNow.Infraestructure;

public class User: BaseModel
{
    public int id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
    public string type { get; set; }
    public string? plan { get; set; }
    public string roles { get; set; }
    
}