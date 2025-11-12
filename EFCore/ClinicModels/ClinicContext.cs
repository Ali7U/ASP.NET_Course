using Microsoft.EntityFrameworkCore;

namespace EFCore.ClinicModels;

public class ClinicContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointments> Appointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Clinic;User Id=SA; Password=06_Ali@g;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>()
            .Property(d => d.LastName)
            .HasDefaultValue("AlFulani");
        
        modelBuilder.Entity<Appointments>()
            .Property(a => a.CreatedAt)
            .HasDefaultValueSql("GetDate()");
    }
}