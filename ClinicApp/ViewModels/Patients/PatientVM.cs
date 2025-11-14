using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicApp.ViewModels.Patients;

public class PatientVM
{
    public int Id { get; set; }
    [MaxLength(50)]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = null!;
    [MaxLength(10), RegularExpression("[12]\\d{9}", ErrorMessage = "The input should be in the form 1xxxxxxxxx or 2xxxxxxx")]
    [Display(Name = "National ID")]
    public string NationalId { get; set; } = null!;
    [MaxLength(150), EmailAddress]
    public string Email { get; set; } = null!;
    [MaxLength(10)]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; } = null!;
    [Display(Name = "Date of Birth")]
    public DateOnly DateOfBirth { get; set; }

}