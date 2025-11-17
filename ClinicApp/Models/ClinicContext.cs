using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Models;

public class ClinicContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointments> Appointments { get; set; }
    
    public ClinicContext(DbContextOptions<ClinicContext> options)
        : base(options) { }
    

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