using Microsoft.EntityFrameworkCore;

namespace RepairNow.Infraestructure.Context;

public class RepairNowDB: DbContext //Base de datos
{
    
    //Representacion de nuestras tablas
    public DbSet<User> Users { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Appointment>Appointments { get; set; }
    public DbSet<Appliance>Appliances { get; set; }
    
    
    
    //Constructores de la base de datos

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) //Si no está configurado 
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("server=localhost;user=root;password=Gunsnroses123#;database=repairnowdb",serverVersion);
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
        base.OnModelCreating(builder); //Estoy sobrescribiendo al padre o metodo original
        
        //User Table
        builder.Entity<User>().ToTable("Users"); //Relacion con la tabla 
        builder.Entity<User>().HasKey(p => p.id); //El parametro id va a ser la tabla primaria
        builder.Entity<User>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd(); //Que se autogenere por cada nuevo valor
        builder.Entity<User>().Property(p => p.firstName).IsRequired().HasMaxLength(60); //Maximo tamanio de la propiedad
        builder.Entity<User>().Property(p => p.DateCreated).IsRequired().HasDefaultValue(DateTime.Now); //Damos un valor por defecto
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