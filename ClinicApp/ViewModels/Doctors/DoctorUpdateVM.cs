using System.ComponentModel.DataAnnotations;
using ClinicApp.Models;

namespace ClinicApp.ViewModels.Doctors;

public class DoctorUpdateVM
{
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; } = null!;
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Display(Name = "Hire Date")]
    public DateTime HireDate { get; set; }

    public Doctor ToModel()
    {
        return new Doctor
        {
            FirstName = FirstName,
            LastName = LastName,
            PhoneNumber = PhoneNumber,
            Email = Email,
            HireDate = HireDate
        };
    }
}