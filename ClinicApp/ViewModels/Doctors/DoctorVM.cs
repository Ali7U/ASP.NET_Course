using System.ComponentModel.DataAnnotations;

namespace ClinicApp.ViewModels.Doctors;

public class DoctorVM
{
    public int Id { get; set; }
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; } = null!;
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Display(Name = "Hire Date")]
    public DateTime HireDate { get; set; }
}