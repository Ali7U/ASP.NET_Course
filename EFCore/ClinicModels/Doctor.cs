using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.ClinicModels;

public class Doctor
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    
    [Column(TypeName = "date")]
    public DateTime HireDate { get; set; }

    public List<Appointments> Appointments { get; set; } = new();
}