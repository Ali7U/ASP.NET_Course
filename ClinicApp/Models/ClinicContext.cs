using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Models;

public class ClinicContext : IdentityDbContext<AppUser>
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointments> Appointments { get; set; }
    
    public ClinicContext(DbContextOptions<ClinicContext> options)
        : base(options) { }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppUser>(t => t.ToTable("Users"));
        modelBuilder.Entity<IdentityRole>(t => t.ToTable("Roles"));
        modelBuilder.Entity<IdentityUserRole<string>>(t => t.ToTable("UserRoles"));
        modelBuilder.Entity<IdentityUserClaim<string>>(t => t.ToTable("UserClaims"));
        modelBuilder.Entity<IdentityUserLogin<string>>(t => t.ToTable("UserLogins"));
        modelBuilder.Entity<IdentityRoleClaim<string>>(t => t.ToTable("RoleClaims"));
        modelBuilder.Entity<IdentityUserToken<string>>(t => t.ToTable("UserTokens"));

        modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole
                {
                    Id = "ad90e18a-ab7f-4bb0-9f73-5778de3b4a1", 
                    Name = AppRoles.APP_ADMIN.ToString(),
                    NormalizedName = AppRoles.APP_ADMIN.ToString(),
                    ConcurrencyStamp = "ad90e18a-ab7f-4bb0-9f73-5778de3b4a1"
                },
                new IdentityRole
                {
                    Id = "20251109185744-ad90e18a-ab7f-4bb0-9f73-5778de3b4a1", 
                    Name = AppRoles.DOCTOR.ToString(),
                    NormalizedName = AppRoles.DOCTOR.ToString(),
                    ConcurrencyStamp = "20251109185744-ad90e18a-ab7f-4bb0-9f73-5778de3b4a1"
                },
                new IdentityRole
                {
                    Id = "ad90e18a-ab7f-4bb0-9f75-5778de3b4a1f", 
                    Name = AppRoles.RECEPTIONIST.ToString(), 
                    NormalizedName = AppRoles.RECEPTIONIST.ToString(), 
                    ConcurrencyStamp = "ad90e18a-ab7f-4bb0-9f75-5778de3b4a1f"
                }
            );
        

        modelBuilder.Entity<Doctor>()
            .Property(d => d.LastName)
            .HasDefaultValue("AlFulani");
        
        modelBuilder.Entity<Appointments>()
            .Property(a => a.CreatedAt)
            .HasDefaultValueSql("GetDate()");
    }
}