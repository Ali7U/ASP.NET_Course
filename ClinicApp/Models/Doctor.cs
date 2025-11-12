using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicApp.Models;

public class Doctor
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string? LastName { get; set; }
    public string PhoneNumber { get; set; } = null!;
    
    [MaxLength(150), EmailAddress]
    public string Email { get; set; } = null!;
    
    [Column(TypeName = "date")]
    public DateTime HireDate { get; set; }

    public List<Appointments> Appointments { get; set; } = new();
}