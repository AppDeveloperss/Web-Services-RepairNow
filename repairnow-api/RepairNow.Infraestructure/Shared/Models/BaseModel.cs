namespace RepairNow.Infraestructure;

public abstract class BaseModel
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdate { get; set; } //? -> PARA QUE ACEPTE NULOS
    public bool isActive { get; set; }
}