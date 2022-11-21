using Microsoft.EntityFrameworkCore;

namespace RepairNow.Infraestructure.Context;

public class RepairNowDB: DbContext 
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Appointment>Appointments { get; set; }
    public DbSet<Appliance>Appliances { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) 
        {
            // 8  0   29
            var serverVersion = new MySqlServerVersion(new Version(5, 5, 62));
            //"Server=localhost,3306;Uid=root;Pwd=LaUpc123*;Database=LearningCenterDB"
            //"Server=sql10.freemysqlhosting.net;User ID=sql10579414;Password=GtlkhVbHlU;Database=sql10579414"
            optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10579414;Pwd=GtlkhVbHlU;Database=sql10579414",serverVersion);
        }
    }
    public RepairNowDB():base()
    {
        
    }

    public RepairNowDB(DbContextOptions<RepairNowDB>options) : base(options)
    {
        
    }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); 
        
        //User Table
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.id); 
        builder.Entity<User>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd(); 
        builder.Entity<User>().Property(p => p.firstName).IsRequired().HasMaxLength(60); 
        builder.Entity<User>().Property(p => p.DateCreated).IsRequired().HasDefaultValue(DateTime.Now); 
        builder.Entity<User>().Property(p => p.isActive).IsRequired().HasDefaultValue(true);
        builder.Entity<User>().Property(p => p.plan).HasDefaultValue(null);

        //Report Table
        builder.Entity<Report>().ToTable("Reports");
        builder.Entity<Report>().HasKey(p => p.id);
        builder.Entity<Report>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Report>().Property(p => p.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Entity<Report>().Property(p => p.isActive).IsRequired().HasDefaultValue(true);
        
        // Appointment Table
        builder.Entity<Appointment>().ToTable("Appointments");
        builder.Entity<Appointment>().HasKey(p => p.id);
        builder.Entity<Appointment>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Appointment>().Property(p => p.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Entity<Appointment>().Property(p => p.isActive).IsRequired().HasDefaultValue(true);
        
        //Appliance Table
        builder.Entity<Appliance>().ToTable("Appliances");
        builder.Entity<Appliance>().HasKey(p => p.id);
        builder.Entity<Appliance>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Appliance>().Property(p => p.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Entity<Appliance>().Property(p => p.isActive).IsRequired().HasDefaultValue(true);
        
        
    }
    
    
}