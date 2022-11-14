using Microsoft.EntityFrameworkCore;
using RepairNow.Infraestructure.Context;

namespace RepairNow.Infraestructure;

public class UsersRepository:IUsersRepository
{
    private RepairNowDB _repairNowDb;
    public UsersRepository(RepairNowDB repairNowDb)
    {
        _repairNowDb = repairNowDb;
    }
    public List<User> getAll()
    {
        return _repairNowDb.Users.Where(user=>user.isActive).ToList();
    }

    public User getUserById(int id)
    {
        return _repairNowDb.Users.Find(id);
    }

    public async Task<bool> createUser(User user)
    {
        
        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
                _repairNowDb.Users.AddAsync(user);
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

    public async Task<bool> updateUser(int id, User user_new)
    {
        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
                User user=await _repairNowDb.Users.FindAsync(id);
                user.DateUpdate=DateTime.Now;
               user.firstName = user_new.firstName;
               user.lastName = user_new.lastName;
               user.email = user_new.email;
               user.password = user_new.password;
               user.phone = user_new.phone;
               user.plan = user_new.plan;
               user.address = user_new.address;
               
               _repairNowDb.Users.Update(user);
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

    public async Task<bool> deleteUser(int id)
    {
        using (var transacction = _repairNowDb.Database.BeginTransactionAsync())
        {
            try
            {
                
                User user = await _repairNowDb.Users.FindAsync(id);
                user.isActive = false;
                user.DateUpdate=DateTime.Now;
                _repairNowDb.Users.Update(user);
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