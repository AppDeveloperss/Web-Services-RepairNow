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

    public async Task<bool> updateAppliance(int id, Appliance new_appliance)
    {
        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
                //User user = _repairNowDb.Users.Find(id);
                Appliance appliance = await _repairNowDb.Appliances.FindAsync(id);

                appliance.DateUpdate = DateTime.Now;

                appliance.name = new_appliance.name;
                appliance.description = new_appliance.description;
                appliance.brand = new_appliance.brand;
                appliance.model = new_appliance.model;
                appliance.year = new_appliance.year;
                appliance.urlImage = new_appliance.urlImage;
                appliance.insuranceDate = new_appliance.insuranceDate;
                appliance.clientId = new_appliance.clientId;

                _repairNowDb.Appliances.Update(appliance);
                _repairNowDb.SaveChanges();
            }
            catch (Exception ex)
            {
                _repairNowDb.Database.RollbackTransactionAsync();
            }
        }
        
        _repairNowDb.Database.CommitTransactionAsync(); 
        return true;
    }

    public async Task<bool> deleteAppliance(int id)
    {
        
        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
                Appliance appliance = await _repairNowDb.Appliances.FindAsync(id);
                appliance.isActive = false;
                appliance.DateUpdate=DateTime.Now;
                _repairNowDb.Appliances.Update(appliance);
                _repairNowDb.SaveChanges();
            }
            catch (Exception ex)
            {
                _repairNowDb.Database.RollbackTransactionAsync();
            }
        }
        
        _repairNowDb.Database.CommitTransactionAsync(); 
        return true;
    }
}
