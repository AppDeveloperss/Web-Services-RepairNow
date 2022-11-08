namespace RepairNow.Infraestructure;

public interface IAppliancesRepository
{
    List<Appliance> getAll();
    Appliance getApplianceById(int id);
    Task<Boolean> createAppliance(string name);

    Boolean updateAppliance(int id, string name);
    Boolean deleteAppliance(int id);
}