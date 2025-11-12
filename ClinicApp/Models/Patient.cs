using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicApp.Models;

public class Patient
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string FullName { get; set; } = null!;
    [MaxLength(10)]
    public string NationalId { get; set; } = null!;
    [MaxLength(150), EmailAddress]
    public string Email { get; set; } = null!;
    [MaxLength(10)]
    public string PhoneNumber { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }

    public List<Appointments> Appointments { get; set; } = new();
}