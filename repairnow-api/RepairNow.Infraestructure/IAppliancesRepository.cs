namespace RepairNow.Infraestructure;

public interface IAppliancesRepository
{
    List<Appliance> getAll();
    Appliance getApplianceById(int id);
    Task<Boolean> createAppliance(Appliance appliance);
    Task<Boolean> updateAppliance(int id, Appliance appliance);
    Boolean deleteAppliance(int id);
}