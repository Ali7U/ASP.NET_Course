using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.ClinicModels;

public class Patient
{
    public int PatientId { get; set; }
    public string FullName { get; set; } = null!;
    public string NationalId { get; set; } = null!;
    [MaxLength(150), EmailAddress]
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }

    public List<Appointments> Appointments { get; set; } = new();
}