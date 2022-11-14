using RepairNow.Infraestructure.Context;

namespace RepairNow.Infraestructure;

public class AppliancesRepository:IAppliancesRepository
{
    private RepairNowDB _repairNowDb;
    public AppliancesRepository(RepairNowDB repairNowDb)
    {
        _repairNowDb = repairNowDb;
    }
    
    public List<Appliance> getAll()
    {
        return _repairNowDb.Appliances.Where(appliance=>appliance.isActive).ToList(); 
    }

    public Appliance getApplianceById(int id)
    {
        return _repairNowDb.Appliances.Find(id);
    }

    public async Task<bool> createAppliance(Appliance appliance)
    {

        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
                _repairNowDb.Appliances.AddAsync(appliance);
                _repairNowDb.SaveChanges();
            }
            catch (Exception ex)
            {
                _repairNowDb.Database.RollbackTransactionAsync();//Si pasa algo malo entonces lo anula(hace rollback)
            }
        }
        
        _repairNowDb.Database.CommitTransactionAsync(); //Si no pasa algo malo entonces good
        return true;
    }

    public bool updateAppliance(int id, string name)
    {
        throw new NotImplementedException();
    }

    public bool deleteAppliance(int id)
    {
        throw new NotImplementedException();
    }
}