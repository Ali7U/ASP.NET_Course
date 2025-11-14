using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClinicApp.ViewModels.Doctors;

namespace ClinicApp.Models;

public class Doctor
{
    public int Id { get; set; }
    
    [MaxLength(50), Required]
    public string FirstName { get; set; }
    
    [MaxLength(50), Required]
    public string? LastName { get; set; }
    [Required]
    public string PhoneNumber { get; set; } = null!;
    [MaxLength(150), Required]
    public string Email { get; set; } = null!;
    
    [Column(TypeName = "date")]
    public DateTime HireDate { get; set; }

    public List<Appointments> Appointments { get; set; } = new();

    public DoctorVM ToDoctorVM()
    {
        return new DoctorVM
        {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            PhoneNumber = PhoneNumber,
            Email = Email,
            HireDate = HireDate
        };
    }
}