using RepairNow.Infraestructure;

namespace RepairNow.Domain;

public interface IAppliancesDomain
{
    List<Appliance> getAll();
    Appliance getApplianceById(int id);
    Task<Boolean> createAppliance(Appliance appliance);
    Boolean updateAppliance(int id, string name);
    Boolean deleteAppliance(int id);
}